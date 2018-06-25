using System.Threading;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace DriverExplorer.Model.Tests
{
    public class DriverExplorerTest 
    {
        private readonly DriverExplorer _DriverExplorer = new DriverExplorer();
        private readonly ITestOutputHelper _output;
        private const string CDrive = "C:\\";

        public DriverExplorerTest(ITestOutputHelper output) 
        {
            _output = output;
        }

        [Fact]
        public void AllDrives_returns_drive_c() 
        {
            var res = _DriverExplorer.AllDrives;
            res.Should().Contain(CDrive);
        }

        [Fact]
        public void GetDriveDescriptor_returns_null_when_drives_not_found() 
        {
            var res = _DriverExplorer.GetDriveDescriptor("NotFound", null, CancellationToken.None);
            res.Should().BeNull();
        }

        [Fact]
        public void GetDriveDescriptor_returns_not_null_when_drives_found() 
        {
            var res = _DriverExplorer.GetDriveDescriptor(_DriverExplorer.AllDrives[0], null, CancellationToken.None);
            res.Should().NotBeNull();
        }

        [Fact]
        public void GetDriveDescriptor_returns_driver_with_name() 
        {
            var res = _DriverExplorer.GetDriveDescriptor(CDrive, null, CancellationToken.None);
            res.Name.Should().Be(CDrive);
        }

        [Fact]
        public void GetDriveDescriptor_returns_driver_with_size() 
        {
            var res = _DriverExplorer.GetDriveDescriptor(CDrive, null, CancellationToken.None);
            res.Size.SizeInByte.Should().BeGreaterThan(0);
            _output.WriteLine($"Size: {res.Size}");
        }

        [Fact]
        public void GetDriveDescriptor_returns_driver_with_free_space() 
        {
            var res = _DriverExplorer.GetDriveDescriptor(CDrive, null, CancellationToken.None);
            res.FreeSpace.SizeInByte.Should().BeInRange(0, res.Size.SizeInByte);
            _output.WriteLine($"FreeSpace: {res.FreeSpace}");
        }

        [Fact]
        public void GetDriveDescriptor_returns_driver_with_root_driver()
        {
            var res = _DriverExplorer.GetDriveDescriptor(CDrive, null, CancellationToken.None);
            res.Root.Name.Should().Be(CDrive);
        }
    }
}
