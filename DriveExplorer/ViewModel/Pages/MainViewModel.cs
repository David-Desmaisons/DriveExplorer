using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using DriveExplorer.Application.WindowServices;
using DriveExplorer.Model;
using DriveExplorer.ViewModel.Core;
using Neutronium.MVVMComponents;
using Neutronium.MVVMComponents.Relay;
using Vm.Tools.Async;

namespace DriveExplorer.ViewModel.Pages
{
    public class MainViewModel : Vm.Tools.ViewModel
    {
        public DriveBasicDescriptionViewModel[] Drives { get; }

        private DiscEntityViewModel _Root;
        public DiscEntityViewModel Root
        {
            get { return _Root; }
            set { Set(ref _Root, value); }
        }

        private DriveBasicDescriptionViewModel _Drive;
        public DriveBasicDescriptionViewModel Drive
        {
            get { return _Drive; }
            set { Set(ref _Drive, value); }
        }

        public ISimpleCommand<DiscEntityViewModel> OpenDirectory { get; }
        public TaskCommand<DiscEntityViewModel, string> FileAnalyser { get; }

        private readonly IDriverExplorer _DriverExplorer;
        private readonly INotificationSender _NotificationSender;

        public MainViewModel(IDriverExplorer driverExplorer, INotificationSender notificationSender)
        {
            _DriverExplorer = driverExplorer;
            _NotificationSender = notificationSender;
            _Drive = null;
            Drives = driverExplorer.AllDrives.Select(m => new DriveBasicDescriptionViewModel(m)).ToArray();
            OpenDirectory = new RelaySimpleCommand<DiscEntityViewModel>(Open);
            FileAnalyser = new TaskCommand<DiscEntityViewModel, string>(DoAnalyse) {CanBeExecuted = false};
            FileAnalyser.Results.Subscribe(OnResult);
            PropertyChanged += MainViewModel_PropertyChanged;
        }

        private void OnResult(CommandResult<DiscEntityViewModel> result)
        {
            if (result.Success)
            {
                Root = result.Result;
                return;
            }

            var notification =  Notification.Error(string.Format(Resource.ProblemDuringDiskAnalyse, _Drive.DisplayName),
                                string.Format(Resource.ExceptionRaised, result.Exception.Message));
            _NotificationSender.Send(notification);
        }

        private void MainViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(Drive))
                return;

            PropertyChanged -= MainViewModel_PropertyChanged;
            FileAnalyser.CanBeExecuted = true;
        }

        private void Open(DiscEntityViewModel discEntityViewModel)
        {
        }


        private DiscEntityViewModel DoAnalyse(CancellationToken cancellationToken, IProgress<string> progress)
        {
            var res = _DriverExplorer.GetDriveDescriptor(_Drive.Name, progress, cancellationToken);
            return null;
        }
    }
}
