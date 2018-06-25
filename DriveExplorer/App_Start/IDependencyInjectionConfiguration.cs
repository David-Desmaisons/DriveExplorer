using System;
using Microsoft.Practices.ServiceLocation;

namespace DriverExplorer {
    public interface IDependencyInjectionConfiguration {
        Lazy<IServiceLocator> GetServiceLocator();

        void Register<T>(T implementation);
    }
}