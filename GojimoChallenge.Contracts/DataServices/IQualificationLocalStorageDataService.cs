using System.Collections.Generic;
using System.Threading.Tasks;
using GojimoChallenge.Contracts.Models;

namespace GojimoChallenge.Contracts.DataServices
{
    public interface IQualificationLocalStorageDataService
    {
        void SaveQualifications(List<IQualification> data);
        Task<List<IQualification>> GetSavedQualifications();
        string GetETag();
        void SaveETag(string eTag);
    }
}