using HT.Framework;
using HT.Interview.ChatBot.Common.Entities;
using System;
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
        /// Get users by role id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response<IEnumerable<UserDetail>>> GetUsersByRoleIdAsync(int roleId);

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
        /// Update user interview date async
        /// </summary>
        /// <param name="userId"></param> 
        /// <returns></returns>
        Task<Response> UpdateUserInterviewDateAsync(int userId, string modifiedBy);

        /// <summary>
        /// Update user interview completed async
        /// </summary>
        /// <param name="userId"></param> 
        /// <returns></returns>
        Task<Response> UpdateUserInterviewCompletedAsync(int userId, string modifiedBy);

        /// <summary>
        /// Update user interview result async
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="remark"></param>
        /// <param name="endResult"></param>
        /// <param name="modifiedBy"></param>
        /// <returns></returns>
        Task<Response> UpdateUserInterviewResultAsync(int userId, string remark, string endResult, string modifiedBy);

        /// <summary>
        /// Update user recording details async
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="recordingFilePath"></param>
        /// <param name="modifiedBy"></param>
        /// <returns></returns>
        Task<Response> UpdateUserRecordingDetailAsync(int userId, string recordingFilePath, string modifiedBy);

        /// <summary>
        /// Delete user async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response> DeleteUserAsync(int id);

    }
}
