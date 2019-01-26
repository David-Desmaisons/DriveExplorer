using System;
using CommonServiceLocator;

namespace DriverExplorer.UI
{
    public interface IDependencyInjectionConfiguration
    {
        Lazy<IServiceLocator> GetServiceLocator();

        void Register<T>(T implementation);
    }
}