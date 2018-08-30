using HT.Framework;
using HT.Interview.ChatBot.Common.Entities;
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
        /// <param name="user"></param>
        Task<Response> GetUsersAsync(User user); 
    }
}
