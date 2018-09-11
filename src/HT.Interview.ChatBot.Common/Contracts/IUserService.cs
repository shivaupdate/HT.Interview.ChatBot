using HT.Framework;
using HT.Interview.ChatBot.Common.DTO;
using HT.Interview.ChatBot.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// IUserService
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get users async
        /// </summary>
        /// <param name="uq"></param>
        Task<Response<IEnumerable<User>>> GetUsersAsync(UserRequest uq); 
    }
}
