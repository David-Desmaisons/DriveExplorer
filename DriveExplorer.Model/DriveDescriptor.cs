
namespace DriveExplorer.Model 
 {
    public class DriveDescriptor
    {
        public string Name { get; }
        public ByteSize Size { get; }
        public ByteSize FreeSpace { get; }
        public DirectoryDescriptor Root { get; }

        public DriveDescriptor(string name, long size, long freeSpace, DirectoryDescriptor root)
        {
            Name = name;
            Size = new ByteSize(size);         
            FreeSpace = new ByteSize(freeSpace);
            Root = root;
        }

        public override string ToString() => $"{Name} - {Size}";
    }
}

