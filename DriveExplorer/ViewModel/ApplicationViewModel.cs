using System.Threading.Tasks;
using DriveExplorer.Application.Navigation;
using DriveExplorer.Application.WindowServices;
using DriveExplorer.ViewModel.Modal;
using Neutronium.WPF.ViewModel;

namespace DriveExplorer.ViewModel {
    public class ApplicationViewModel : Vm.Tools.ViewModel, IMessageBox, INotificationSender {
        public ApplicationInformation ApplicationInformation { get; } = new ApplicationInformation();
        public IWindowViewModel Window { get; }
        public NavigationViewModel Router { get; }

        public object CurrentViewModel { get; set; }

        private MessageModalViewModel _Modal;
        public MessageModalViewModel Modal
        {
            get { return _Modal; }
            private set { Set(ref _Modal, value); }
        }

        private Notification _Notification = null;
        public Notification Notification
        {
            get { return _Notification; }
            set { Set(ref _Notification, value); }
        }

        public ApplicationViewModel(IWindowViewModel window, NavigationViewModel router) {
            Window = window;
            Router = router;
        }

        public Task<bool> ShowMessage(ConfirmationMessage confirmationMessage) {
            var modal = new MainModalViewModel(confirmationMessage);
            Modal = modal;
            return modal.CompletionTask;
        }

        public void ShowInformation(MessageInformation messageInformation) {
            var modal = new MessageModalViewModel(messageInformation);
            Modal = modal;
        }

        public void Send(Notification notification) {
            Notification = notification;
        }
    }
}
