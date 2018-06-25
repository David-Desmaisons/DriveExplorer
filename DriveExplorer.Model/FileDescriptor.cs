
namespace DriverExplorer.Model 
 {
    public class FileDescriptor
    {
        public ByteSize Size { get; }
        public string Name { get; }

        public FileDescriptor(string name, long size) 
        {
            Size = new ByteSize(size);
            Name = name;
        }

        public override string ToString() => $"{Name} - {Size}";
    }
}

