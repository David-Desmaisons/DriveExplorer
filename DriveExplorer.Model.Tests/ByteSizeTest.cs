using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace DriveExplorer.Model.Tests
{
    public class ByteSizeTest 
    {
        private const int _Factor = 1024;

        [Theory]
        [AutoData]
        public void SizeInByte_returns_original_value(long size) 
        {
            var res = new ByteSize(size);
            res.SizeInByte.Should().Be(size);
        }

        [Theory]
        [AutoData]
        public void FromKB_creates_size_with_correct_byte_size(long size) 
        {
            var res = ByteSize.FromKB(size);
            res.SizeInByte.Should().Be(size * _Factor);
        }

        [Theory]
        [AutoData]
        public void FromMB_creates_size_with_correct_byte_size(long size)
        {
            var res = ByteSize.FromMB(size);
            res.SizeInByte.Should().Be(size * _Factor * _Factor);
        }

        [Theory]
        [AutoData]
        public void FromGB_creates_size_with_correct_byte_size(long size)
        {
            var res = ByteSize.FromGB(size);
            res.SizeInByte.Should().Be(size * _Factor * _Factor * _Factor);
        }

        [Theory]
        [InlineData(3, "3 Bytes")]
        [InlineData(310, "310 Bytes")]
        [InlineData(999, "999 Bytes")]
        [InlineData(1000, "0,98 KB")]
        [InlineData(1024, "1,00 KB")]
        [InlineData(1536, "1,50 KB")]
        [InlineData(102400, "100,00 KB")]
        [InlineData(1022976, "999,00 KB")]
        [InlineData(1024000, "0,98 MB")]
        [InlineData(1048576, "1,00 MB")]
        [InlineData(25165824, "24,00 MB")]
        [InlineData(1048565514, "999,99 MB")]
        [InlineData(1073741824, "1,00 GB")]
        [InlineData(178241142784, "166,00 GB")]
        [InlineData(1073731086581, "999,99 GB")]
        [InlineData(1099511627776, "1,00 TB")]
        [InlineData(2199023255552, "2,00 TB")]
        public void ToString_returns_information_depending_on_size(long size, string expected) 
        {
            var res = new ByteSize(size);
            res.ToString().Should().Be(expected);
        }
    }
}
