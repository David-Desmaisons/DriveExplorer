using DriveExplorer.Model;

namespace DriverExplorer.UI.ViewModel.Core
{
    public class SizeViewModel
    {
        public long Value { get; }

        public SizeViewModel(ByteSize byteSize)
        {
            Value = byteSize.SizeInByte;
        }
    }
}
