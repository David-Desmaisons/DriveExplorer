using System;
using DriveExplorer.Localization;
using DriveExplorer.Model;

namespace DriveExplorer.ViewModel.Core
{
    public class DriveBasicDescriptionViewModel
    {
        public DriveBasicDescriptionViewModel(DriveBasicDescription driveBasicDescription)
        {
            Name = driveBasicDescription.Name;
            DriveType = driveBasicDescription.DriveType.Humanize();
            IsReady = driveBasicDescription.IsReady;
            VolumeLabel = driveBasicDescription.VolumeLabel;
        }
        //
        // Summary:
        //     Gets the name of a drive, such as C:\.
        //
        // Returns:
        //     The name of the drive.
        public string Name { get; }
        //
        // Summary:
        //     Gets the drive type, such as CD-ROM, removable, network, or fixed.
        //
        // Returns:
        //     One of the enumeration values that specifies a drive type.
        public string DriveType { get; }
        //
        // Summary:
        //     Gets a value that indicates whether a drive is ready.
        //
        // Returns:
        //     true if the drive is ready; false if the drive is not ready.
        public bool IsReady { get; }
        //
        // Summary:
        //     Gets or sets the volume label of a drive.
        //
        // Returns:
        //     The volume label.
        public string VolumeLabel { get; }

        public string DisplayName => $"{(String.IsNullOrEmpty(VolumeLabel) ? DriveType: VolumeLabel)} ({Name.Replace(@"\","")})";
    }
}
