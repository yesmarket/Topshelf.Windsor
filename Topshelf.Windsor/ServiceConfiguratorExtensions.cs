using Topshelf.ServiceConfigurators;

namespace Topshelf.Windsor
{
    public static class ServiceConfiguratorExtensions
    {
        public static ServiceConfigurator<T> ConstructUsingWindsor<T>(this ServiceConfigurator<T> configurator)
            where T : class
        {
            configurator.ConstructUsing(serviceFactory => WindsorHostBuilderConfigurator.Container.Resolve<T>());
            return configurator;
        }
    }
}