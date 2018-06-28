using DriveExplorer.Model;

namespace DriveExplorer.ViewModel.Core
{
    public class SizeViewModel
    {
        public string Name { get;  }
        public long Value { get; }

        public SizeViewModel(ByteSize byteSize)
        {
            Name = byteSize.ToString();
            Value = byteSize.SizeInByte;
        }
    }
}
