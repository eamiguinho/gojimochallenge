using Autofac;
using GojimoChallenge.Contracts.IoC;
using GojimoChallenge.Contracts.Services;
using GojimoChallenge.Services.Implementation.Qualifications;

namespace GojimoChallenge.Services.Implementation
{
    public static class IocServicesRegister
    {
        public static void Register()
        {
            Ioc.Instance.RegisterType<QualificationService>().As<IQualificationService>().SingleInstance();
        }
    }
}
