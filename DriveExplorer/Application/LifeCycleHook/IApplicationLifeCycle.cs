using System.ComponentModel;
using DriveExplorer.Application.Navigation;

namespace DriveExplorer.Application.LifeCycleHook {
    public interface IApplicationLifeCycle {
        void OnNavigating(RoutingEventArgs routingEvent);

        void OnNavigated(RoutedEventArgs routedEvent);

        void OnClosing(CancelEventArgs cancelEvent);

        void OnSessionEnding(CancelEventArgs cancelEvent);

        void OnClosed();
    }
}
