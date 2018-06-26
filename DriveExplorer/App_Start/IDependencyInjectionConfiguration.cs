using System;
using Microsoft.Practices.ServiceLocation;

namespace DriveExplorer {
    public interface IDependencyInjectionConfiguration {
        Lazy<IServiceLocator> GetServiceLocator();

        void Register<T>(T implementation);
    }
}