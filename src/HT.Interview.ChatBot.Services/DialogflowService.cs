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
    /// Dialogflow Service
    /// </summary>
    public class DialogflowService : IDialogflowService
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
        public DialogflowService(IChatBotDataFactory factory, IChatBotDataContext chatbotDataContext)
        {
            _chatbotDataContext = chatbotDataContext;
            _resourceService = factory.GetResourceService(Common.Constants.ResourceComponent);
        }

        #region Get-Check User Claims

        /// <summary>
        /// Get intents async
        /// </summary>
        /// <param name="uq"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<Intent>>> GetIntentsAsync()
        {
            IEnumerable<Intent> intents = await _chatbotDataContext.Intent
                .Include(x => x.IntentSuggestion)
                .Include(x => x.IntentTrainingPhrase).ToListAsync();
            return Response.Ok(intents); 
        }

        #endregion

        #endregion
    }
}