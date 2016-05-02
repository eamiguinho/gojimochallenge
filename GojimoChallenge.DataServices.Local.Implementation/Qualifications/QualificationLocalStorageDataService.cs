using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acr.Settings;
using GojimoChallenge.Contracts.DataServices;
using GojimoChallenge.Contracts.Dto;
using GojimoChallenge.Contracts.Dto.Factories;
using GojimoChallenge.Contracts.Models;
using Newtonsoft.Json;
using PCLStorage;

namespace GojimoChallenge.DataServices.Local.Implementation.Qualifications
{
    public class QualificationLocalStorageDataService : IQualificationLocalStorageDataService
    {
        public async void SaveQualifications(List<IQualification> data)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            var dtoList = data.Select(QualificationDtoFactory.GetDto);
            IFile file = await rootFolder.CreateFileAsync("qualifications.json",
                CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(JsonConvert.SerializeObject(dtoList));
        }

        public async Task<List<IQualification>> GetSavedQualifications()
        {
            try
            {
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                IFile file = await rootFolder.GetFileAsync("qualifications.json");
                var text = await file.ReadAllTextAsync();
                var savedDtos = JsonConvert.DeserializeObject<List<QualificationDto>>(text);
                return savedDtos.Select(QualificationDtoFactory.Create).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string GetETag()
        {
          return Settings.Local.Get<string>("eTag", string.Empty);
        }

        public void SaveETag(string eTag)
        {
            Settings.Local.Set("eTag", eTag);
        }
    }
}