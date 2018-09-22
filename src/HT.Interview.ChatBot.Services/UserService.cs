﻿using HT.Framework;
using HT.Framework.Contracts;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using HT.Interview.ChatBot.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Get user by email async
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Response<User>> GetUserByEmailAsync(string email)
        {
            User user = await _chatbotDataContext.User.AsNoTracking().Where(x => x.Email == email && x.IsActive == true).FirstOrDefaultAsync();
            return Response.Ok(user);
        }

        /// <summary>
        /// Get users async
        /// </summary>
        /// <param name="userDetail"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<UserDetail>>> GetUsersAsync(UserDetail userDetail)
        {
            IEnumerable<UserDetail> userDetails = await _chatbotDataContext.UserDetail.AsNoTracking().ToListAsync();
            return Response.Ok(userDetails);
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
        public async Task<Response> UpdateUserAsync(User user)
        {
            if (user == null)
            {
                string message = _resourceService.GetString(Common.Constants.UpdateUserRequestIsNull);
                return Response.Fail(message, ResponseType.InvalidRequest);
            }

            User u = await GetUserByIdAsync(user.Id);
            if (u == null)
            {
                string message = string.Format(_resourceService.GetString(Common.Constants.UserByIdNotFound), u.Id);
                return Response.Fail(message, ResponseType.ResourceNotFound);
            }

            u.PhotoUrl = user.PhotoUrl;
            u.SocialAccountInfo = user.SocialAccountInfo;
            u.ModifiedOn = DateTime.UtcNow.Date;
            u.ModifiedBy = user.Email;

            _chatbotDataContext.User.Attach(u);
            await _chatbotDataContext.SaveChangesAsync();

            return Response.Ok();
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


        #region Private Functions

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<User> GetUserByIdAsync(int id)
        {
            return await _chatbotDataContext.User.FirstOrDefaultAsync(x => x.Id == id);
        }

        #endregion
    }
}