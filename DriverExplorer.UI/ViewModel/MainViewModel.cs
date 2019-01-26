using DriveExplorer.Model;
using DriverExplorer.UI.ViewModel.Core;
using Neutronium.BuildingBlocks.Application.WindowServices;
using Neutronium.BuildingBlocks.ApplicationTools;
using Neutronium.BuildingBlocks.Wpf.Async;
using Neutronium.MVVMComponents;
using Neutronium.MVVMComponents.Relay;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace DriverExplorer.UI.ViewModel
{
    public class MainViewModel : Neutronium.BuildingBlocks.ViewModel
    {
        public DriveBasicDescriptionViewModel[] Drives { get; }

        private DiscEntityViewModel _Root;

        public DiscEntityViewModel Root
        {
            get => _Root;
            set => Set(ref _Root, value);
        }

        private DriveBasicDescriptionViewModel _Drive;

        public DriveBasicDescriptionViewModel Drive
        {
            get => _Drive;
            set => Set(ref _Drive, value);
        }

        private string _Progress;

        public string Progress
        {
            get => _Progress;
            set => Set(ref _Progress, value);
        }

        public ISimpleCommand<DiscEntityViewModel> OpenDirectory { get; }
        public TaskCommand<DiscEntityViewModel, PorcentageProgress> FileAnalyser { get; }

        private readonly IDriverExplorer _DriverExplorer;
        private readonly INotificationSender _NotificationSender;

        public MainViewModel(IDriverExplorer driverExplorer, INotificationSender notificationSender)
        {
            _DriverExplorer = driverExplorer;
            _NotificationSender = notificationSender;
            _Drive = null;
            Drives = driverExplorer.AllDrives.Select(m => new DriveBasicDescriptionViewModel(m)).ToArray();
            OpenDirectory = new RelaySimpleCommand<DiscEntityViewModel>(Open);
            FileAnalyser = new TaskCommand<DiscEntityViewModel, PorcentageProgress>(DoAnalyse, TimeSpan.FromMilliseconds(10))
            {
                CanBeExecuted = false
            };
            FileAnalyser.Results.Subscribe(OnResult);
            FileAnalyser.Progress.Subscribe(OnProgress);
            PropertyChanged += MainViewModel_PropertyChanged;
        }

        private void OnResult(CommandResult<DiscEntityViewModel> result)
        {
            Progress = string.Empty;
            if (result.Success)
            {
                Root = result.Result;
                return;
            }

            var notification = Notification.Error(string.Format(Resource.ProblemDuringDiskAnalyse, _Drive.DisplayName),
                result.Exception.Message);
            _NotificationSender.Send(notification);
        }

        private void OnProgress(PorcentageProgress result)
        {
            Progress = result.ToString();
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

        private DiscEntityViewModel DoAnalyse(CancellationToken cancellationToken, IProgress<PorcentageProgress> progress)
        {
            var res = _DriverExplorer.GetDriveDescriptor(_Drive.Name, progress, cancellationToken);
            return new DiscEntityViewModel(res);
        }
    }
}
