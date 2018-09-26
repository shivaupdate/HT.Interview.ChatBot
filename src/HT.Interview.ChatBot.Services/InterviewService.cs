using HT.Framework;
using HT.Framework.Contracts;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using HT.Interview.ChatBot.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = HT.Interview.ChatBot.Common.Entities;
using System.Linq;

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
        public async Task<Response> AddInterviewAsync(int userId, string dialogflowGeneratedIntentId, string botResponse, string createdBy)
        {
            try
            {
                int? intentId = null;
                try
                {
                    intentId = await GetIntentIdByDialogflowGeneratedIntentIdAsync(dialogflowGeneratedIntentId);
                }
                catch (Exception)
                {

                }

                Model.Interview interview = new Model.Interview()
                {
                    UserId = userId,
                    IntentId = intentId,
                    BotResponse = botResponse,
                    CreatedBy = createdBy,
                    CreatedOn = DateTime.Now
                };

                _chatbotDataContext.Interview.Add(interview);
                await _chatbotDataContext.SaveChangesAsync();

                return Response.Ok();
            }
            catch (Exception)
            {
                return Response.Fail("InvalidRequest", ResponseType.InvalidRequest);

            }
        }

        /// <summary>
        /// Add interview async
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dialogflowGeneratedIntentId"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<InterviewDetail>>> GetInterviewDetailAsync(int userId)
        {
            IEnumerable<InterviewDetail> interviewDetails = await _chatbotDataContext.InterviewDetail.Where(x => x.UserId == userId).ToListAsync();
            return Response.Ok(interviewDetails);
        }


        /// <summary>
        /// Update interview async
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dialogflowGeneratedIntentId"></param>
        /// <param name="givenAnswer"></param>
        /// <param name="timeTaken"></param>
        /// <returns></returns>
        public async Task<Response> UpdateInterviewAsync(int userId, string dialogflowGeneratedIntentId, string userResponse, int? timeTaken, string modifiedBy)
        {
            try
            {
                int intentId = await GetIntentIdByDialogflowGeneratedIntentIdAsync(dialogflowGeneratedIntentId);
                Model.Interview i = await GetInterviewByCandidateIdAndIntentIdAsync(userId, intentId);
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
            catch (Exception ex)
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
        private async Task<int> GetIntentIdByDialogflowGeneratedIntentIdAsync(string dialogflowGeneratedIntentId)
        {
            Model.Intent result = await _intentService.GetIntentByDialogflowGeneratedIntentIdAsync(dialogflowGeneratedIntentId);
            return result.Id;
        }

        /// <summary>
        /// Get interview by candidate id and intent id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="intentId"></param>
        /// <returns></returns>
        private async Task<Model.Interview> GetInterviewByCandidateIdAndIntentIdAsync(int userId, int intentId)
        {
            return await _chatbotDataContext.Interview.FirstOrDefaultAsync(x => x.UserId == userId && x.IntentId == intentId);
        }

        #endregion
    }
}