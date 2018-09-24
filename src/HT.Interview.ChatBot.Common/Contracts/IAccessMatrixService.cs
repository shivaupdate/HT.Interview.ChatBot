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
        /// Get access matrix async
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<Response<IEnumerable<AccessMatrix>>> GetAccessMatrixByRoleIdAsync(int roleId); 
    }
}
