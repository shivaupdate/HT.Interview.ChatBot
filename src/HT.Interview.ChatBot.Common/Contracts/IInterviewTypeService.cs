using HT.Framework; 
using HT.Interview.ChatBot.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// InterviewTypeService
    /// </summary>
    public interface IInterviewTypeService
    {
        /// <summary>
        /// Get roles async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        Task<Response<IEnumerable<InterviewType>>> GetInterviewTypesAsync(int? id, string type, string createdBy);
    }
}
