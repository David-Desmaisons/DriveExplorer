using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace DriveExplorer.Model 
{
    public class DriverExplorer : IDriverExplorer 
    {
        public string[] AllDrives { get; }

        public DriverExplorer() 
        {
            var drives = DriveInfo.GetDrives();
            AllDrives = drives.Select(d => d.Name).ToArray();
        }

        public DriveDescriptor GetDriveDescriptor(string name, IProgress<string> progress, CancellationToken cancellationToken) 
        {
            var drive = DriveInfo.GetDrives().SingleOrDefault(d => d.Name == name);
            if (drive == null)
                return null;

            var root = FromPathDirectoryInfo(new DirectoryInfo(name));
            var result = new DriveDescriptor(name, drive.TotalSize, drive.TotalFreeSpace, root);
            return result;
        }

        private static DirectoryDescriptor FromPathDirectoryInfo(DirectoryInfo directoryInfo)
        {
            DirectoryInfo[] directories;
            try 
            {
                directories = directoryInfo.GetDirectories();
            }
            catch (UnauthorizedAccessException) 
            {
                return new DirectoryDescriptor(directoryInfo.Name, false);
            }

            var res = new DirectoryDescriptor(directoryInfo.Name, true);
            foreach (var directory in directories)
            {
                var child = FromPathDirectoryInfo(directory);
                res.Directories.Add(child);
            }
            foreach (var fileInfo in directoryInfo.GetFiles())
            {
                var file = new FileDescriptor(fileInfo.Name, fileInfo.Length);
                res.Files.Add(file);
            }
            return res;
        }
    }
}
