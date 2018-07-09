using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace DriveExplorer.Model
{
    public class DriverExplorer : IDriverExplorer
    {
        public DriveBasicDescription[] AllDrives { get; }

        public DriverExplorer()
        {
            var drives = DriveInfo.GetDrives();
            AllDrives = drives.Select(GetDriveBasicDescription).ToArray();
        }

        private static DriveBasicDescription GetDriveBasicDescription(DriveInfo driveInfo)
        {
            var isReady = driveInfo.IsReady;
            var volumeLabel = default(string);
            try
            {
                volumeLabel = isReady ? driveInfo.VolumeLabel : null;
            }
            catch
            {
            }
            return new DriveBasicDescription(driveInfo.Name, driveInfo.DriveType, isReady, volumeLabel);
        }

        private class WorkContext
        {
            private int? Total { get; }
            internal int Current { get; set; }

            public WorkContext(int total)
            {
                Total = total;
                Current = 0;
            }

            public WorkContext()
            {
                Total = null;
                Current = 0;
            }

            internal PorcentageProgress GetProgress()
            {
                return new PorcentageProgress(Total, Current);
            }
        }

        public DriveDescriptor GetDriveDescriptor(string name, IProgress<PorcentageProgress> progress, CancellationToken cancellationToken)
        {
            var drive = DriveInfo.GetDrives().SingleOrDefault(d => d.Name == name);
            if (drive == null)
                return null;

            var driveInfo = new DirectoryInfo(name);
            var current = GetFirstProgress(driveInfo);
            progress.Report(current.GetProgress());
            var root = FromPathDirectoryInfo(driveInfo, progress, current);
            var result = new DriveDescriptor(name, drive.TotalSize, drive.TotalFreeSpace, root);
            progress.Report(current.GetProgress());
            return result;
        }

        private static DirectoryDescriptor FromPathDirectoryInfo(DirectoryInfo directoryInfo, IProgress<PorcentageProgress> progress, WorkContext current)
        {
            DirectoryInfo[] directories;
            try
            {
                directories = directoryInfo.GetDirectories();
            }
            catch (PathTooLongException)
            {
                return new DirectoryDescriptor(directoryInfo.Name, false);
            }
            catch (UnauthorizedAccessException)
            {
                return new DirectoryDescriptor(directoryInfo.Name, false);
            }

            var res = new DirectoryDescriptor(directoryInfo.Name, true);
            foreach (var directory in directories)
            {
                var child = FromPathDirectoryInfo(directory, progress, current);
                res.Directories.Add(child);
            }
            foreach (var fileInfo in directoryInfo.GetFiles())
            {
                var file = new FileDescriptor(fileInfo.Name, fileInfo.Length);
                res.Files.Add(file);
                current.Current++;
                progress.Report(current.GetProgress());
            }
            return res;
        }

        private static WorkContext GetFirstProgress(DirectoryInfo directoryInfo)
        {
            try
            {
                return new WorkContext(directoryInfo.GetFiles("*", SearchOption.AllDirectories).Length);
            }
            catch
            {
                return new WorkContext();
            }
        }
    }
}
