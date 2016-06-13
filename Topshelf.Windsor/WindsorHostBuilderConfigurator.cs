using System;
using System.Collections.Generic;
using Castle.Windsor;
using Topshelf.Builders;
using Topshelf.Configurators;
using Topshelf.HostConfigurators;

namespace Topshelf.Windsor
{
    public class WindsorHostBuilderConfigurator : HostBuilderConfigurator
    {
        private static Action<IWindsorContainer> _action;

        private static IWindsorContainer _container;

        public WindsorHostBuilderConfigurator(Action<IWindsorContainer> action)
        {
            _action = action;
        }

        public static IWindsorContainer Container
        {
            get
            {
                if (_container != null) return _container;
                _container = new WindsorContainer();
                _action.Invoke(_container);
                return _container;
            }
        }

        public IEnumerable<ValidateResult> Validate()
        {
            yield break;
        }

        public HostBuilder Configure(HostBuilder builder)
        {
            return builder;
        }
    }
}