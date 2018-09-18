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

        #region Public Functions

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

        public async Task<Response> AddRoleAsync(Role role)
        {
            try
            {
                _chatbotDataContext.Role.Add(role);
                await _chatbotDataContext.SaveChangesAsync();
                return Response.Ok();
            }
            catch (System.Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public async Task<Response> DeleteRoleAsync(Role role)
        {
            try
            {
                _chatbotDataContext.Role.Remove(role);
                await _chatbotDataContext.SaveChangesAsync();
                return Response.Ok();
            }
            catch (System.Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        #region Get Roles

        /// <summary>
        /// Get roles async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<Role>>> GetRolesAsync(int? id, string name, string createdBy)
        {
            IEnumerable<Role> roles = await _chatbotDataContext.Role.ToListAsync();
            // TODO: Search roles result list against search parameters
            return Response.Ok(roles);
        }

        public async Task<Response> UpdateRoleAsync(Role role)
        {
            try
            {
                _chatbotDataContext.Role.Update(role);
                await _chatbotDataContext.SaveChangesAsync();
                return Response.Ok();
            }
            catch (System.Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        #endregion

        #endregion
    }
}