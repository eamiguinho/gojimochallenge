using System.Collections.Generic;
using System.Threading.Tasks;
using GojimoChallenge.Contracts.Models;
using GojimoChallenge.Contracts.Results;

namespace GojimoChallenge.Contracts.Services
{
    public interface IQualificationService
    {
        Task<DataResult<List<IQualification>>> GetQualifications();
        void SetCurrentQualification(IQualification model);
        IQualification GetCurrentQualificiation();
    }
}
