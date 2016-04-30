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

        public QualificationService(IQualificationDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<DataResult<List<IQualification>>> GetQualifications()
        {
            var eTag = Settings.Local.Get<string>("eTag", string.Empty);
            var qualifications = await _dataService.GetQualifications(eTag);
            if (qualifications.IsOk)
            {
                SaveQualifications(qualifications.Data);
                Settings.Local.Set("eTag",qualifications.ETag);
                return qualifications;
            }
            var savedQualifications =  await GetSavedQualifications();
            if (savedQualifications != null)
                return new DataResult<List<IQualification>>(savedQualifications);
            return new DataResult<List<IQualification>>(Result.Error);
        }

        private async Task<List<IQualification>> GetSavedQualifications()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFile file = await rootFolder.GetFileAsync("qualifications.json");
            var text = await file.ReadAllTextAsync();
            var savedDtos = JsonConvert.DeserializeObject<List<QualificationDto>>(text);
            return savedDtos.Select(QualificationDtoFactory.Create).ToList();
        }

        private async void SaveQualifications(List<IQualification> data)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            var dtoList = data.Select(QualificationDtoFactory.GetDto);
            IFile file = await rootFolder.CreateFileAsync("qualifications.json",
                CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(JsonConvert.SerializeObject(dtoList));
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
