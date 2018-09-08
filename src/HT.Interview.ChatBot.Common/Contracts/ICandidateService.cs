using HT.Framework; 
using HT.Interview.ChatBot.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// ICandidateService
    /// </summary>
    public interface ICandidateService
    {
        /// <summary>
        /// Get Candidate async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        Task<Response<IEnumerable<Candidate>>> GetCandidatesAsync(Candidate candidate);
    }
}
