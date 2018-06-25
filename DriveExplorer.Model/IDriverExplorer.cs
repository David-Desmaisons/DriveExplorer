using System;
using System.Collections.Generic;
using System.Threading;

namespace DriverExplorer.Model 
{
    public interface IDriverExplorer 
    {
        List<string> AllDrives { get; }

        DriveDescriptor GetDriveDescriptor(string name, IProgress<string> progress, CancellationToken cancellationToken);
    }
}
