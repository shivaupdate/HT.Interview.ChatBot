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
    /// Role Service
    /// </summary>
    public class InterviewTypeService : IInterviewTypeService
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
        public InterviewTypeService(IChatBotDataFactory factory, IChatBotDataContext chatbotDataContext)
        {
            _chatbotDataContext = chatbotDataContext;
            _resourceService = factory.GetResourceService(Common.Constants.ResourceComponent);
        }

        #region Get InterviewTypes

        /// <summary>
        /// Get InterviewTypes async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<InterviewType>>> GetInterviewTypesAsync(int? id, string name, string createdBy)
        {
            IEnumerable<InterviewType> InterviewTypes = await _chatbotDataContext.InterviewType.ToListAsync();
            // TODO: Search InterviewTypes result list against search parameters
            return Response.Ok(InterviewTypes);
        }

        #endregion

        #endregion
    }
}