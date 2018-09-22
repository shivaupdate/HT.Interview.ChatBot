using HT.Framework;
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
        /// Get user by email async
        /// </summary>
        /// <param name="email"></param>
        Task<Response<User>> GetUserByEmailAsync(string email);

        /// <summary>
        /// Get users async
        /// </summary>
        /// <param name="userDetail"></param>
        Task<Response<IEnumerable<UserDetail>>> GetUsersAsync(UserDetail userDetail);

        /// <summary>
        /// Create user async
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<Response> CreateUserAsync(User user);

        /// <summary>
        /// Update user async
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<Response> UpdateUserAsync(User user);

        /// <summary>
        /// Delete user async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response> DeleteUserAsync(int id);
    }
}
