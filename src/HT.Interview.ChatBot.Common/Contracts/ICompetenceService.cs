using HT.Framework; 
using HT.Interview.ChatBot.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// ICompetenceService
    /// </summary>
    public interface ICompetenceService
    {
        /// <summary>
        /// Get Competences async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        Task<Response<IEnumerable<Competence>>> GetCompetencesAsync(int? id, string name, string createdBy);
    }
}
