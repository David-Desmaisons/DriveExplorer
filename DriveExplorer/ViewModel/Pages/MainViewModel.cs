using DriveExplorer.Model;

namespace DriveExplorer.ViewModel.Pages
{
    public class MainViewModel : Vm.Tools.ViewModel
    {
        private readonly IDriverExplorer _DriverExplorer;

        public string[] Drives { get; }

        private string _Drive;

        public string Drive
        {
            get { return _Drive; }
            set { Set(ref _Drive, value); }
        }

        public MainViewModel(IDriverExplorer driverExplorer)
        {
            _Drive = string.Empty;
            _DriverExplorer = driverExplorer;
            Drives = driverExplorer.AllDrives;
        }
    }
}
