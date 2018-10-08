using HT.Framework;
using HT.Framework.Contracts;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using HT.Interview.ChatBot.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = HT.Interview.ChatBot.Common.Entities;

namespace HT.Interview.ChatBot.Services
{
    /// <inheritdoc />
    /// <summary>
    /// Interview Service
    /// </summary>
    public class InterviewService : IInterviewService
    {
        #region Fields

        private readonly IChatBotDataContext _chatbotDataContext;
        private readonly IContentService _resourceService;
        private readonly IIntentService _intentService;

        #endregion

        #region Public Functions

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="chatbotDataContext"></param>
        public InterviewService(IChatBotDataFactory factory, IChatBotDataContext chatbotDataContext)
        {
            _chatbotDataContext = chatbotDataContext;
            _resourceService = factory.GetResourceService(Common.Constants.ResourceComponent);
            _intentService = factory.GetIntentService();
        }

        /// <summary>
        /// Add interview async
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dialogflowGeneratedIntentId"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<InterviewDetail>>> GetInterviewDetail(int userId)
        {
            IEnumerable<InterviewDetail> interviewDetails = await _chatbotDataContext.InterviewDetail.Where(x => x.UserId == userId).ToListAsync();
            return Response.Ok(interviewDetails);
        }

        /// <summary>
        /// Create interview async
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dialogflowGeneratedIntentId"></param>
        /// <param name="botResponse"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        public async Task<int> CreateResponseAsync(int userId, string dialogflowGeneratedIntentId, string botResponse, string createdBy)
        {
            try
            {  
                Model.Interview interview = new Model.Interview()
                {
                    UserId = userId,
                    IntentId = await GetIntentIdByDialogflowGeneratedIntentIdAsync(dialogflowGeneratedIntentId),
                    BotResponse = botResponse,
                    CreatedBy = createdBy,
                    CreatedOn = DateTime.Now
                };

                _chatbotDataContext.Interview.Add(interview);
                await _chatbotDataContext.SaveChangesAsync();
                int interviewId = interview.Id;

                return interviewId;
            }
            catch (Exception)
            {
                return 0;

            }
        }

        /// <summary>
        /// Update interview async
        /// </summary>
        /// <param name="interviewId"></param>
        /// <param name="dialogflowGeneratedIntentId"></param>
        /// <param name="userResponse"></param>
        /// <param name="timeTaken"></param>
        /// <param name="modifiedBy"></param>
        /// <returns></returns>
        public async Task<Response> UpdateResponseAsync(int interviewId, string userResponse, int? timeTaken, string modifiedBy)
        {
            try
            { 
                Model.Interview i = await GetInterviewByInterviewIdAsync(interviewId); 
                i.UserResponse = userResponse;
                if (timeTaken.HasValue)
                {
                    i.TimeTaken = timeTaken.Value;
                }
                i.ModifiedOn = DateTime.UtcNow.Date;
                i.ModifiedBy = modifiedBy;

                _chatbotDataContext.Interview.Attach(i);
                await _chatbotDataContext.SaveChangesAsync();

                return Response.Ok();
            }
            catch (Exception)
            {
                return Response.Fail("InvalidRequest", ResponseType.InvalidRequest);
            }
        }

        #endregion

        #region Private Functions

        /// <summary>
        /// Get interview by candidate id and intent id
        /// </summary>
        /// <param name="candidateId"></param>
        /// <param name="intentId"></param>
        /// <returns></returns>
        private async Task<int?> GetIntentIdByDialogflowGeneratedIntentIdAsync(string dialogflowGeneratedIntentId)
        {
            int? intentId = null;
            try
            {
                intentId = (await _intentService.GetIntentByDialogflowGeneratedIntentIdAsync(dialogflowGeneratedIntentId)).Id;
            }
            catch(Exception)
            {

            }
            return intentId;
        }

        /// <summary>
        /// Get interview by interview id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="intentId"></param>
        /// <returns></returns>
        private async Task<Model.Interview> GetInterviewByInterviewIdAsync(int interviewId)
        {
            return await _chatbotDataContext.Interview.FirstOrDefaultAsync(x => x.Id == interviewId);
        }

        #endregion
    }
}