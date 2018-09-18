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
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        Task<Response<IEnumerable<Role>>> GetRolesAsync(int? id, string name, string createdBy);

        /// <summary>
        /// Add Role async
        /// </summary>
        /// <param name="role class"></param>      
        /// <returns></returns>
        Task<Response> AddRoleAsync(Role role);

        /// <summary>
        /// Update Role async
        /// </summary>
        /// <param name="Role class"></param>      
        /// <returns></returns>
        Task<Response> UpdateRoleAsync(Role role);

        /// <summary>
        /// Delete Role async
        /// </summary>
        /// <param name="Role class"></param>      
        /// <returns></returns>
        Task<Response> DeleteRoleAsync(Role role);
    }
}
