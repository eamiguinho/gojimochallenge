using System.Threading.Tasks;
using Autofac;
using GojimoChallenge.Contracts.DataServices;
using GojimoChallenge.Contracts.IoC;
using GojimoChallenge.DataServices.Implementation;
using GojimoChallenge.Models;
using GojimoChallenge.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GojimoChallenge.DataServices.Online.Test
{
    [TestClass]
    public class QualificationDataServiceTests
    {
        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            IocModelsRegister.Register();
            IocServicesRegister.Register();
            IocDataServicesRegister.Register();
        }

        [TestMethod]
        public async Task QualificationDataTest(string eTag)
        {
            var dataService = Ioc.Container.Resolve<IQualificationDataService>();
            var results = await dataService.GetQualifications(eTag);
            Assert.IsNotNull(results);
            Assert.IsTrue(results.IsOk);
            Assert.IsNotNull(results.Data);
        }

        [TestMethod]
        public async Task QualificationDataErrorTest(string eTag)
        {
            var dataService = Ioc.Container.Resolve<IQualificationDataService>();
            var results = await dataService.GetQualifications(eTag);
            Assert.IsNotNull(results);
            Assert.IsFalse(results.IsOk);
            Assert.IsNotNull(results.ErrorMessage);
            Assert.IsNull(results.Data);
        }
    }
}
