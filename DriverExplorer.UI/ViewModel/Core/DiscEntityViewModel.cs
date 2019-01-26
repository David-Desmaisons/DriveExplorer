using System.Linq;
using DriveExplorer.Model;
using DriveExplorer.ViewModel.Core;

namespace DriverExplorer.UI.ViewModel.Core
{
    public class DiscEntityViewModel
    {
        public string Name { get; }
        public bool IsAcessible { get; }
        public DiscEntityViewModel[] Children { get; }
        public SizeViewModel Size { get; }

        public DiscEntityViewModel(DriveDescriptor driveDescriptor) : this(driveDescriptor.Root)
        {
        }

        public DiscEntityViewModel(DirectoryDescriptor directoryDescriptor)
        {
            Name = directoryDescriptor.Name;
            IsAcessible = directoryDescriptor.IsAcessible;
            Size = null;
            Children = directoryDescriptor.Directories.Select(d => new DiscEntityViewModel(d)).Concat(
                directoryDescriptor.Files.Select(d => new DiscEntityViewModel(d))
            ).ToArray();
        }

        public DiscEntityViewModel(FileDescriptor fileDescriptor)
        {
            Name = fileDescriptor.Name;
            IsAcessible = true;
            Size = new SizeViewModel(fileDescriptor.Size);
            Children = null;
        }
    }
}
