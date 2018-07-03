using System;
using System.Threading;

namespace DriveExplorer.Model 
{
    public interface IDriverExplorer 
    {
        DriveBasicDescription[] AllDrives { get; }

        DriveDescriptor GetDriveDescriptor(string name, IProgress<string> progress, CancellationToken cancellationToken);
    }
}
