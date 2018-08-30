using AutoMapper;
using HT.Framework;
using HT.Framework.Contracts;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.DTO;
using HT.Interview.ChatBot.Common.Entities;
using HT.Interview.ChatBot.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Services
{
    /// <inheritdoc />
    /// <summary>
    /// User Claim Service
    /// </summary>
    public class UserService : IUserService
    {
        #region Fields

        private readonly IChatBotDataContext _chatbotDataContext;
        private readonly ILogger<IUserService> _logger;
        private readonly IContentService _resourceService;

        #endregion

        #region Public Functions

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="masterDataContext"></param>
        public UserService(IChatBotDataFactory factory, IChatBotDataContext chatbotDataContext)
        {
            _chatbotDataContext = chatbotDataContext;
            //_logger = factory.GetFrameworkFactory().GetLoggingService<IUserService>();
            //_resourceService = factory.GetFrameworkFactory().GetResourceService(Common.Constants.ResourceComponent);
        }

        #region Get-Check User Claims
         
        /// <inheritdoc />
        /// <summary>
        /// <para>This function can return records based on loggedInUserId i.e. based on user permission to View, Create, Update and Delete User Claims if GetManageableOnly is set to true.</para>
        /// <para>Otherwise it will get records independent of user permission</para>
        /// </summary>
        /// <param name="uc"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<User>>> GetUsersAsync(UserQuery uq)
        {
            IEnumerable<User> users = await _chatbotDataContext.User.ToListAsync();
            return Response.Ok(users);
        }

        #endregion
         
        #endregion

        #region Private Functions
         
        /// <summary>
        /// Log Error Message
        /// </summary>
        /// <param name="errorMessage"></param>
        private void LogError(string errorMessage)
        {
            _logger.LogError(errorMessage);
        }

        #endregion
    }
}