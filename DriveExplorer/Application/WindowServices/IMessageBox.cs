using System.Threading.Tasks;

namespace DriveExplorer.Application.WindowServices {
    public interface IMessageBox {
        Task<bool> ShowMessage(ConfirmationMessage confirmationMessage);

        void ShowInformation(MessageInformation messageInformation);
    }
}