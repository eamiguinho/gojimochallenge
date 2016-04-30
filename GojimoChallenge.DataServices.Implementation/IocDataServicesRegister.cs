using Autofac;
using GojimoChallenge.Contracts.DataServices;
using GojimoChallenge.Contracts.IoC;
using GojimoChallenge.Contracts.Services;
using GojimoChallenge.DataServices.Implementation.Qualifications;

namespace GojimoChallenge.DataServices.Implementation
{
    public static class IocDataServicesRegister
    {
        public static void Register()
        {
            Ioc.Instance.RegisterType<QualificationDataService>().As<IQualificationDataService>().SingleInstance();
        }
    }
}
