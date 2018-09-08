using HT.Framework; 
using HT.Interview.ChatBot.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// ICompetenceLevelService
    /// </summary>
    public interface ICompetenceLevelService
    {
        /// <summary>
        /// Get CompetenceLevels async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        Task<Response<IEnumerable<CompetenceLevel>>> GetCompetenceLevelsAsync(int? id, string name, string createdBy);
    }
}
