using HT.Framework; 
using HT.Interview.ChatBot.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// IJobProfileService
    /// </summary>
    public interface IJobProfileService
    {
        /// <summary>
        /// Get job profiles async
        /// </summary>
        /// <param name="jobProfile"></param>
        /// <returns></returns>
        Task<Response<IEnumerable<JobProfile>>> GetJobProfilesAsync(JobProfile jobProfile);
    }
}
