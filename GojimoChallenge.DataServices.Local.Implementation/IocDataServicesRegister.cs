using Autofac;
using GojimoChallenge.Contracts.DataServices;
using GojimoChallenge.Contracts.IoC;
using GojimoChallenge.DataServices.Local.Implementation.Qualifications;

namespace GojimoChallenge.DataServices.Local.Implementation
{
    public static class IocLocalDataServicesRegister
    {
        public static void Register()
        {
            Ioc.Instance.RegisterType<QualificationLocalStorageDataService>().As<IQualificationLocalStorageDataService>().SingleInstance();
        }
    }
}
