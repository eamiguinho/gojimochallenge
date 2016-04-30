using Autofac;
using GojimoChallenge.Contracts.IoC;
using GojimoChallenge.Contracts.Models;

namespace GojimoChallenge.Models
{
    public static class IocModelsRegister
    {
        public static void Register()
        {
            Ioc.Instance.RegisterType<Qualification>().As<IQualification>();
            Ioc.Instance.RegisterType<Subject>().As<ISubject>();
        }
    }
}
