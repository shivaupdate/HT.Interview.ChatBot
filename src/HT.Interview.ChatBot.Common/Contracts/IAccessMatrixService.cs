using HT.Framework; 
using HT.Interview.ChatBot.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
//using HT.Interview.ChatBot.API.DTO.Request;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// IAccessMatrixService
    /// </summary>
    public interface IAccessMatrixService
    {
        /// <summary>
        /// Get Accessmatrix async
        /// </summary>
        /// <param name="Accessmatrix class"></param>

        /// <returns></returns>
        Task<Response<IEnumerable<AccessMatrix>>> GetAccessMatrixsAsync(AccessMatrix accessMatrix);
    }
}
