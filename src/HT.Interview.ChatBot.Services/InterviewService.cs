using HT.Framework;
using HT.Framework.Contracts;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Data;
using Microsoft.EntityFrameworkCore;
using System;
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
        /// <param name="candidateId"></param>
        /// <param name="dialogflowGeneratedIntentId"></param>
        /// <returns></returns>
        public async Task<Response> AddInterviewAsync(int candidateId, string dialogflowGeneratedIntentId)
        {
            try
            {
                Model.Interview interview = new Model.Interview()
                {
                    InterviewTypeId = 1,
                    CandidateId = candidateId,
                    IntentId = await GetIntentIdByDialogflowGeneratedIntentIdAsync(dialogflowGeneratedIntentId),
                    CreatedBy = "RavindraK@hexaware.com",
                    CreatedOn = DateTime.Now
                };

                _chatbotDataContext.Interview.Add(interview);
                await _chatbotDataContext.SaveChangesAsync();

                return Response.Ok();
            }
            catch (Exception ex)
            {
                string test = ex.Message;
                return null;
            }
        }


        /// <summary>
        /// Update interview async
        /// </summary>
        /// <param name="candidateId"></param>
        /// <param name="dialogflowGeneratedIntentId"></param>
        /// <param name="givenAnswer"></param>
        /// <param name="timeTaken"></param>
        /// <returns></returns>
        public async Task<Response> UpdateInterviewAsync(int candidateId, string dialogflowGeneratedIntentId, string givenAnswer, int? timeTaken)
        {
            try
            { 
                int intentId = await GetIntentIdByDialogflowGeneratedIntentIdAsync(dialogflowGeneratedIntentId); 
                Model.Interview i = await GetInterviewByCandidateIdAndIntentIdAsync(candidateId, intentId); 
                i.GivenAnswer = givenAnswer;
                if (timeTaken.HasValue)
                {
                    i.TimeTaken = timeTaken.Value;
                }
                i.ModifiedOn = DateTime.UtcNow.Date;
                i.ModifiedBy = "RavindraK@hexaware.com";

                _chatbotDataContext.Interview.Attach(i);
                await _chatbotDataContext.SaveChangesAsync();

                return Response.Ok();
            }
            catch (Exception ex)
            {
                string test = ex.Message;
                return null;
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
        /// <param name="candidateId"></param>
        /// <param name="intentId"></param>
        /// <returns></returns>
        private async Task<Model.Interview> GetInterviewByCandidateIdAndIntentIdAsync(int candidateId, int intentId)
        {
            return await _chatbotDataContext.Interview.FirstOrDefaultAsync(x => x.CandidateId == candidateId && x.IntentId == intentId);
        }

        #endregion
    }
}