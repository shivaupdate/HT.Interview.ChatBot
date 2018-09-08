using HT.Framework;
using HT.Framework.Contracts;
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

        #region Get AccessMatrixs

        /// <summary>
        /// Get AccessMatrixs async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<AccessMatrix>>> GetAccessMatrixsAsync(AccessMatrix accessMatrix)
        {
            IEnumerable<AccessMatrix> AccessMatrixs = await _chatbotDataContext.AccessMatrix.ToListAsync();
            // TODO: Search AccessMatrixs result list against search parameters
            return Response.Ok(AccessMatrixs);
        }

        #endregion

        #endregion
    }
}