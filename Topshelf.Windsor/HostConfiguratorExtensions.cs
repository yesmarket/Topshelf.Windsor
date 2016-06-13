using System;
using Castle.Windsor;
using Topshelf.HostConfigurators;

namespace Topshelf.Windsor
{
    public static class HostConfiguratorExtensions
    {
        public static HostConfigurator UseWindsor(
            this HostConfigurator configurator,
            Action<IWindsorContainer> action)
        {
            configurator.AddConfigurator(new WindsorHostBuilderConfigurator(action));
            return configurator;
        }
    }
}