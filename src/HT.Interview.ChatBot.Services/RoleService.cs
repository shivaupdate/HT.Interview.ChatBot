using HT.Framework;
using HT.Framework.Contracts;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using HT.Interview.ChatBot.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Services
{
    /// <inheritdoc />
    /// <summary>
    /// Role Service
    /// </summary>
    public class RoleService : IRoleService
    {
        #region Fields

        private readonly IChatBotDataContext _chatbotDataContext;
        private readonly IContentService _resourceService;

        #endregion
         
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="chatbotDataContext"></param>
        public RoleService(IChatBotDataFactory factory, IChatBotDataContext chatbotDataContext)
        {
            _chatbotDataContext = chatbotDataContext;
            _resourceService = factory.GetResourceService(Common.Constants.ResourceComponent);
        }

        /// <summary>
        /// Get roles async
        /// </summary>
        /// <returns></returns>
        public async Task<Response<IEnumerable<Role>>> GetRolesAsync()
        {
            IEnumerable<Role> roles = await _chatbotDataContext.Role.ToListAsync();
            // TODO: Search roles result list against search parameters
            return Response.Ok(roles);
        } 
    }
}