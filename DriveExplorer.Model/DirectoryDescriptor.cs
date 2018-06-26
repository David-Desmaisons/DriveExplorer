using System.Collections.Generic;

namespace DriveExplorer.Model 
 {
    public class DirectoryDescriptor 
    {
        public string Name { get; }
        public bool IsAcessible { get; }
        public List<FileDescriptor> Files { get; } = new List<FileDescriptor>();
        public List<DirectoryDescriptor> Directories { get; } = new List<DirectoryDescriptor>();

        public DirectoryDescriptor(string name, bool isAcessible) 
        {
            Name = name;
            IsAcessible = isAcessible;
        }

        public override string ToString() => $"{Name} ({Files.Count} files)";
    }
}
