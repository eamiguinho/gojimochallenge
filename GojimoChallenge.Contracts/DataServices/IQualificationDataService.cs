using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GojimoChallenge.Contracts.Models;
using GojimoChallenge.Contracts.Results;

namespace GojimoChallenge.Contracts.DataServices
{
    public interface IQualificationDataService
    {
        Task<DataResult<List<IQualification>>> GetQualifications(string eTag);
    }
}
