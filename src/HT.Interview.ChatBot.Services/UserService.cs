using HT.Framework;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.DTO;
using HT.Interview.ChatBot.Common.Entities;
using HT.Interview.ChatBot.Data;
using Microsoft.EntityFrameworkCore;
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
        // private readonly IContentService _resourceService;

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
            // _resourceService = factory.GetResourceService(Common.Constants.ResourceComponent);
        }

        #region Get-Check User Claims

        /// <summary>
        /// Get users async
        /// </summary>
        /// <param name="uq"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<User>>> GetUsersAsync(UserQuery uq)
        {
            IEnumerable<User> users = await _chatbotDataContext.User.ToListAsync();
            return Response.Ok(users);
        }

        #endregion

        #endregion
    }
}