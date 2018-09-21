using HT.Framework;
using HT.Framework.Contracts;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using HT.Interview.ChatBot.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Services
{
    /// <inheritdoc />
    /// <summary>
    /// User Service
    /// </summary>
    public class UserService : IUserService
    {
        #region Fields

        private readonly IChatBotDataContext _chatbotDataContext;
        private readonly IContentService _resourceService;

        #endregion

        #region Public Functions

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="chatbotDataContext"></param>
        public UserService(IChatBotDataFactory factory, IChatBotDataContext chatbotDataContext)
        {
            _chatbotDataContext = chatbotDataContext;
            _resourceService = factory.GetResourceService(Common.Constants.ResourceComponent);
        }

        /// <summary>
        /// Get users async
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<User>>> GetUsersAsync(User user)
        {
            IEnumerable<User> users = await _chatbotDataContext.User.ToListAsync();
            return Response.Ok(users);
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<Response> CreateUserAsync(User user)
        {
            user.CreatedOn = DateTime.Now;  
            _chatbotDataContext.User.Add(user);
            await _chatbotDataContext.SaveChangesAsync(); 
            return Response.Ok();
        }

        /// <summary>
        /// Update user async
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<Response> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete user async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Response> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}