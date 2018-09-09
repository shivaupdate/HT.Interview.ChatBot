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

        #region Get-Check User Claims

        /// <summary>
        /// Get intents async
        /// </summary> 
        /// <returns></returns>
        public async Task<Response<IEnumerable<Intent>>> GetIntentsAsync()
        {
            IEnumerable<Intent> intents = await _chatbotDataContext.Intent 
                .Include(x => x.IntentTrainingPhrase)
                .Include(x => x.IntentParameter)
                .Include(x => x.IntentSuggestion).ToListAsync();
            return Response.Ok(intents); 
        }

        #endregion

        #endregion
    }
}