using Autofac;
using GojimoChallenge.Contracts.IoC;
using GojimoChallenge.Contracts.Services;
using GojimoChallenge.DataServices.Implementation;
using GojimoChallenge.DataServices.Local.Implementation;
using GojimoChallenge.Models;
using GojimoChallenge.Services.Implementation;
using GojimoChallenge.UWP.Services;

namespace GojimoChallenge.UWP
{
    public class Bootstraper
    {
        public Bootstraper()
        {
            IocModelsRegister.Register();
            IocServicesRegister.Register();
            IocDataServicesRegister.Register();
            IocLocalDataServicesRegister.Register();
            Ioc.Instance.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
        }
    }
}
