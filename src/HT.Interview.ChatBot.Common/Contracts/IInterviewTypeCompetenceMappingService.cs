using HT.Framework; 
using HT.Interview.ChatBot.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// IInterviewTypeCompetenceMappingService
    /// </summary>
    public interface IInterviewTypeCompetenceMappingService
    {
        /// <summary>
        /// Get InterviewTypeCompetenceMappings async
        /// </summary>
        /// <param name="interviewTypeId"></param>
        /// <param name="competenceId"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        Task<Response<IEnumerable<InterviewTypeCompetenceMapping>>> GetInterviewTypeCompetenceMappingsAsync(int interviewTypeId, int competenceId, string createdBy);
    }
}
