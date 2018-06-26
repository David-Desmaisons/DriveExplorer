using System;
using System.Threading;

namespace DriveExplorer.Model 
{
    public interface IDriverExplorer 
    {
        string[] AllDrives { get; }

        DriveDescriptor GetDriveDescriptor(string name, IProgress<string> progress, CancellationToken cancellationToken);
    }
}
