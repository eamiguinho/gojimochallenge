using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using GojimoChallenge.Contracts.DataServices;
using GojimoChallenge.Contracts.DataServices.Fakes;
using GojimoChallenge.Contracts.IoC;
using GojimoChallenge.Contracts.Models;
using GojimoChallenge.Contracts.Results;
using GojimoChallenge.Models;
using GojimoChallenge.Services.Implementation.Qualifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GojimoChallenge.Services.Test
{
    [TestClass]
    public class QualificationServiceTest
    {
        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            IocModelsRegister.Register();
        }

        [TestMethod]
        public async Task GetQualificationsOnlineErrorTest()
        {
            // Create the fake stockFeed:
            IQualificationDataService qualificationDataService =
                 new StubIQualificationDataService
                 {
                     GetQualificationsString = s =>
                     {
                         return Task.Run(() => new DataResult<List<IQualification>>(Result.Error)); 
                     }
        
                 };
            IQualificationLocalStorageDataService qualificationLocalStorage =
                new StubIQualificationLocalStorageDataService
                {
                    GetSavedQualifications = () =>
                    {
                        return Task.Run(() => new List<IQualification>());
                    },
                    GetETag = () => null,
                    SaveQualificationsListOfIQualification = list => { },
                    SaveETagString = s => { } 
                };
            var service = new QualificationService(qualificationDataService, qualificationLocalStorage);
            var qualification = await service.GetQualifications();
            Assert.IsFalse(qualification.IsOk);
            Assert.IsTrue(qualification.Result == Result.Error);
        }

        [TestMethod]
        public async Task GetQualificationsOnlineSucessNoItemsTest()
        {
            // Create the fake stockFeed:
            IQualificationDataService qualificationDataService =
                 new StubIQualificationDataService
                 {
                     GetQualificationsString = s =>
                     {
                         return Task.Run(() => new DataResult<List<IQualification>>(Result.Ok));
                     }
                 };
            IQualificationLocalStorageDataService qualificationLocalStorage =
                new StubIQualificationLocalStorageDataService
                {
                    GetSavedQualifications = () =>
                    {
                        return Task.Run(() => new List<IQualification>());
                    },
                    GetETag = () => null,
                    SaveQualificationsListOfIQualification = list => { },
                    SaveETagString = s => { }
                };
            var service = new QualificationService(qualificationDataService, qualificationLocalStorage);
            var qualification = await service.GetQualifications();
            Assert.IsTrue(qualification.IsOk);
            Assert.IsTrue(qualification.Result == Result.Ok);
        }

        [TestMethod]
        public async Task GetQualificationsOnlineSucessWithItemsTest()
        {
            var qualificationMock = Ioc.Container.Resolve<IQualification>();
            qualificationMock.Name = "test1";
            var qualificationList = new List<IQualification>();
            qualificationList.Add(qualificationMock);

            IQualificationDataService qualificationDataService =
                 new StubIQualificationDataService
                 {
                     GetQualificationsString = s =>
                     {
                         return Task.Run(() => new DataResult<List<IQualification>>(qualificationList));
                     }
                 };

            IQualificationLocalStorageDataService qualificationLocalStorage =
                new StubIQualificationLocalStorageDataService
                {
                    GetSavedQualifications = () =>
                    {
                        return Task.Run(() => new List<IQualification>());
                    },
                    GetETag = () => null,
                    SaveQualificationsListOfIQualification = list => { },
                    SaveETagString = s => { }
                };

            var service = new QualificationService(qualificationDataService, qualificationLocalStorage);
            var qualification = await service.GetQualifications();
            Assert.IsTrue(qualification.IsOk);
            Assert.IsTrue(qualification.Result == Result.Ok);
            Assert.IsTrue(qualification.Data.Count > 0);
        }


        [TestMethod]
        public async Task GetQualificationsOnlineSucessNotModifiedTest()
        {
            var qualificationMock = Ioc.Container.Resolve<IQualification>();
            qualificationMock.Name = "test1";
            var qualificationList = new List<IQualification>();
            qualificationList.Add(qualificationMock);

            IQualificationDataService qualificationDataService =
                 new StubIQualificationDataService
                 {
                     GetQualificationsString = s =>
                     {
                         return Task.Run(() => new DataResult<List<IQualification>>(Result.NotModified));
                     }
                 };

            IQualificationLocalStorageDataService qualificationLocalStorage =
                new StubIQualificationLocalStorageDataService
                {
                    GetSavedQualifications = () =>
                    {
                        return Task.Run(() => qualificationList);
                    },
                    GetETag = () => null,
                    SaveQualificationsListOfIQualification = list => { },
                    SaveETagString = s => { }
                };

            var service = new QualificationService(qualificationDataService, qualificationLocalStorage);
            var qualification = await service.GetQualifications();
            Assert.IsTrue(qualification.IsOk);
            Assert.IsTrue(qualification.Result == Result.Ok);
            Assert.IsTrue(qualification.Data.Count > 0);
        }
    }
}
