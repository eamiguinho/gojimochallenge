using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GojimoChallenge.Contracts.DataServices;
using GojimoChallenge.Contracts.Dto;
using GojimoChallenge.Contracts.Dto.Factories;
using GojimoChallenge.Contracts.Models;
using GojimoChallenge.Contracts.Results;
using GojimoChallenge.DataServices.Implementation.Helpers;

namespace GojimoChallenge.DataServices.Implementation.Qualifications
{
    public class QualificationDataService : IQualificationDataService
    {

        public async Task<DataResult<List<IQualification>>> GetQualifications(string eTag)
        {
            try
            {
                var url = string.Format("{0}{1}", OnlineHelper.BaseAddress, OnlineHelper.QualificationRoute);
                var apiCall = await OnlineHelper.CallAPI<List<QualificationDto>>(url, eTag);
                if (apiCall.IsOk)
                    return
                        new DataResult<List<IQualification>>(
                            apiCall.Data.Select(QualificationDtoFactory.Create).ToList(), apiCall.ETag);
                return new DataResult<List<IQualification>>(apiCall.Result);
            }
            catch (Exception e)
            {
                var result = new DataResult<List<IQualification>>(Result.Error);
                result.ErrorMessage = e.Message;
                return result;
            }
        }
    }
}
