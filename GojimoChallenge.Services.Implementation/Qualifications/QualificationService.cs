using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acr.Settings;
using GojimoChallenge.Contracts.DataServices;
using GojimoChallenge.Contracts.Dto;
using GojimoChallenge.Contracts.Dto.Factories;
using GojimoChallenge.Contracts.Models;
using GojimoChallenge.Contracts.Results;
using GojimoChallenge.Contracts.Services;
using Newtonsoft.Json;
using PCLStorage;

namespace GojimoChallenge.Services.Implementation.Qualifications
{
    public class QualificationService : IQualificationService
    {
        private readonly IQualificationDataService _dataService;
        private IQualification _currentQualification;
        private IQualificationLocalStorageDataService _localStorageDataService;

        public QualificationService(IQualificationDataService dataService, IQualificationLocalStorageDataService localStorageDataService)
        {
            _dataService = dataService;
            _localStorageDataService = localStorageDataService;
        }

        public async Task<DataResult<List<IQualification>>> GetQualifications()
        {
            var eTag = _localStorageDataService.GetETag();
            var qualifications = await _dataService.GetQualifications(eTag);
            if (qualifications.IsOk)
            {
                _localStorageDataService.SaveQualifications(qualifications.Data);
                _localStorageDataService.SaveETag(qualifications.ETag);
                return qualifications;
            }
            var savedQualifications =  await _localStorageDataService.GetSavedQualifications();
            if (savedQualifications != null && savedQualifications.Count > 0)
                return new DataResult<List<IQualification>>(savedQualifications);
            return new DataResult<List<IQualification>>(Result.Error);
        }

        public void SetCurrentQualification(IQualification qual)
        {
            _currentQualification = qual;
        }

        public IQualification GetCurrentQualificiation()
        {
            return _currentQualification;
        }
    }
}
