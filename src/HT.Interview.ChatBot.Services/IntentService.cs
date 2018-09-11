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

namespace HT.Interview.ChatBot.Services
{
    /// <inheritdoc />
    /// <summary>
    /// Intent Service
    /// </summary>
    public class IntentService : IIntentService
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
        public IntentService(IChatBotDataFactory factory, IChatBotDataContext chatbotDataContext)
        {
            _chatbotDataContext = chatbotDataContext;
            _resourceService = factory.GetResourceService(Common.Constants.ResourceComponent);
        }

        /// <summary>
        /// Get intents async
        /// </summary> 
        /// <returns></returns>
        public async Task<Response<IEnumerable<Intent>>> GetIntentsAsync()
        {
            IEnumerable<Intent> intents = await _chatbotDataContext.Intent
                .Include(x => x.IntentTrainingPhrase)
                .Include(x => x.IntentParameter)
                .Include(x => x.IntentSuggestion).Where(x=> x.IsActive == true).AsNoTracking().ToListAsync();

            if (intents.Any()) return Response.Ok(intents);
            {
                string message = _resourceService.GetString(Common.Constants.IntentsNotFound);
                return Response.Fail<IEnumerable<Intent>>(message, ResponseType.ResourceNotFound);
            }
        }

        /// <summary>
        /// Update intent async
        /// </summary>
        /// <param name="intent"></param>
        /// <returns></returns>
        public async Task<Response> UpdateIntentsAsync(Intent intent)
        {
            try
            {
                if (intent == null)
                {
                    string message = _resourceService.GetString(Common.Constants.UpdateIntentRequestIsNull);
                    return Response.Fail(message, ResponseType.InvalidRequest);
                }

                Intent i = await GetIntentById(intent.Id);
                if (i == null)
                {
                    string message = string.Format(_resourceService.GetString(Common.Constants.IntentByIdNotFound), intent.Id);
                    return Response.Fail(message, ResponseType.ResourceNotFound);
                }

                i.DialogflowIntentId = intent.DialogflowIntentId;
                i.DialogflowGeneratedName = intent.DialogflowGeneratedName;
                i.DialogflowGeneratedIntent = intent.DialogflowGeneratedIntent;
                i.ModifiedOn = DateTime.UtcNow.Date;
                i.ModifiedBy = "RavindraK@hexaware.com";

                _chatbotDataContext.Intent.Attach(i);
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
        /// Get intent by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<Intent> GetIntentById(int id)
        {
            return await _chatbotDataContext.Intent.FirstOrDefaultAsync(x => x.Id == id);
        }

        #endregion
    }
}