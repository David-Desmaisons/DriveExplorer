using System.ComponentModel;
using DriverExplorer.Application.Navigation;

namespace DriverExplorer.Application.LifeCycleHook {
    public interface IApplicationLifeCycle {
        void OnNavigating(RoutingEventArgs routingEvent);

        void OnNavigated(RoutedEventArgs routedEvent);

        void OnClosing(CancelEventArgs cancelEvent);

        void OnSessionEnding(CancelEventArgs cancelEvent);

        void OnClosed();
    }
}
