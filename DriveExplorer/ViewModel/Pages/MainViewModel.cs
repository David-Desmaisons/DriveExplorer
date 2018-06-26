using DriveExplorer.Model;

namespace DriveExplorer.ViewModel.Pages {
    public class MainViewModel : Vm.Tools.ViewModel {
        private readonly IDriverExplorer _DriverExplorer;

        public string[] Drives { get; }

        public MainViewModel(IDriverExplorer driverExplorer) {
            _DriverExplorer = driverExplorer;
            Drives = driverExplorer.AllDrives;
        }
    }
}
