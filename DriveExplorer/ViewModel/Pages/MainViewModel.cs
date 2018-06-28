using DriveExplorer.Model;
using DriveExplorer.ViewModel.Core;
using Neutronium.MVVMComponents;
using Neutronium.MVVMComponents.Relay;

namespace DriveExplorer.ViewModel.Pages
{
    public class MainViewModel : Vm.Tools.ViewModel
    {
        private readonly IDriverExplorer _DriverExplorer;

        public string[] Drives { get; }

        private DiscEntityViewModel _Root;
        public DiscEntityViewModel Root
        {
            get { return _Root; }
            set { Set(ref _Root, value); }
        }

        private string _Drive;
        public string Drive
        {
            get { return _Drive; }
            set { Set(ref _Drive, value); }
        }

        public ISimpleCommand Load { get; }
        public ISimpleCommand<DiscEntityViewModel> OpenDirectory { get; }

        public MainViewModel(IDriverExplorer driverExplorer)
        {
            _Drive = string.Empty;
            _DriverExplorer = driverExplorer;
            Drives = driverExplorer.AllDrives;
            Load = new RelaySimpleCommand(DoLoad);
            OpenDirectory = new RelaySimpleCommand<DiscEntityViewModel>(Open);
        }

        private void DoLoad()
        {
        }

        private void Open(DiscEntityViewModel discEntityViewModel)
        {
        }
    }
}
