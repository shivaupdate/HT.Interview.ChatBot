using HT.Framework;
using HT.Framework.Contracts;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using HT.Interview.ChatBot.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Services
{
    /// <inheritdoc />
    /// <summary>
    /// AccessMatrix Service
    /// </summary>
    public class AccessMatrixService : IAccessMatrixService
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
        public AccessMatrixService(IChatBotDataFactory factory, IChatBotDataContext chatbotDataContext)
        {
            _chatbotDataContext = chatbotDataContext;
            _resourceService = factory.GetResourceService(Common.Constants.ResourceComponent);
        }

        /// <summary>
        /// Get access matrix async
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<AccessMatrix>>> GetAccessMatrixByRoleIdAsync(int roleId)
        {
            IEnumerable<AccessMatrix> AccessMatrixs = await _chatbotDataContext.AccessMatrix.Where(x => x.RoleId == roleId).ToListAsync();
            return Response.Ok(AccessMatrixs);
        }

        #endregion
    }
}