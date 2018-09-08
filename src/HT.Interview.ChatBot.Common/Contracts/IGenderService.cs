using HT.Framework; 
using HT.Interview.ChatBot.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// IGenderService
    /// </summary>
    public interface IGenderService
    {
        /// <summary>
        /// Get Genders async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        Task<Response<IEnumerable<Gender>>> GetGendersAsync(int? id, string name, string createdBy);
    }
}
