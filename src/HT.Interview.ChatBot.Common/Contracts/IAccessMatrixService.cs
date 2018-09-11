using HT.Framework; 
using HT.Interview.ChatBot.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <summary>
        /// Add AccessMatrix async
        /// </summary>
        /// <param name="AccessMatrix class"></param>      
        /// <returns></returns>
        Task<Response> AddAccessMatrixAsync(AccessMatrix accessMatrix);

        /// <summary>
        /// Update AccessMatrix async
        /// </summary>
        /// <param name="AccessMatrix class"></param>      
        /// <returns></returns>
        Task<Response> UpdateAccessMatrixAsync(AccessMatrix accessMatrix);

        /// <summary>
        /// Delete AccessMatrix async
        /// </summary>
        /// <param name="AccessMatrix class"></param>      
        /// <returns></returns>
        Task<Response> DeleteAccessMatrixAsync(AccessMatrix accessMatrix);
    }
}
