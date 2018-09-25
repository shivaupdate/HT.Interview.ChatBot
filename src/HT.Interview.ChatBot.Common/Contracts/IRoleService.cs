using HT.Framework; 
using HT.Interview.ChatBot.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// IRoleService
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// Get roles async
        /// </summary>
        /// <returns></returns>
        Task<Response<IEnumerable<Role>>> GetRolesAsync(); 
    }
}
