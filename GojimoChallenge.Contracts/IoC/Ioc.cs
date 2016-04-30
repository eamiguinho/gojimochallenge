using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;

namespace GojimoChallenge.Contracts.IoC
{
    public static class Ioc
    {
        private static readonly Lazy<ContainerBuilder> _instance = new Lazy<ContainerBuilder>(() => new ContainerBuilder());
        private static Container _container;

        public static ContainerBuilder Instance
        {
            get { return _instance.Value; }
        }

        public static Container Container
        {
            get { return _container ?? (_container = Instance.Build() as Container); }
        }

    }
}
