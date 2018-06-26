using System;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Neutronium.Core.WebBrowserEngine.Window;
using DriveExplorer.Application.LifeCycleHook;
using DriveExplorer.ViewModel.Pages;
using Neutronium.WPF.Internal;
using Ninject;
using Vm.Tools.Application;
using DriveExplorer.Model;

namespace DriveExplorer {
    public class DependencyInjectionConfiguration : IDependencyInjectionConfiguration {
        private readonly StandardKernel _Kernel;
        private readonly Lazy<IServiceLocator> _ServiceLocator;

        public DependencyInjectionConfiguration() {
            var kernel = new StandardKernel(new NinjectSettings { UseReflectionBasedInjection = true });
            RegisterDependency(kernel);
            _Kernel = kernel;
            _ServiceLocator = new Lazy<IServiceLocator>(() => new NinjectServiceLocator(_Kernel));
        }

        public Lazy<IServiceLocator> GetServiceLocator() => _ServiceLocator;

        public void Register<T>(T implementation) => _Kernel.Bind<T>().ToConstant(implementation);

        public static void RegisterDependency(IKernel kernel) {
            var window = System.Windows.Application.Current.MainWindow;
            var application = new WpfApplication(window);
            kernel.Bind<IApplication>().ToConstant(application);
            kernel.Bind<IDispatcher>().ToConstant(new WPFUIDispatcher(window.Dispatcher));
            kernel.Bind<IApplicationLifeCycle>().To<ApplicationLifeCycle>();
            kernel.Bind<IDriverExplorer>().To<DriverExplorer>();
            kernel.Bind<MainViewModel>().ToSelf().InSingletonScope();
        }
    }
}
