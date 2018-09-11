using HT.Framework;
using HT.Interview.ChatBot.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// IIntentService
    /// </summary>
    public interface IIntentService
    {
        /// <summary>
        /// Get itent by dialogflow generated intent id
        /// </summary>
        /// <param name="dialogflowGeneratedIntentId"></param>
        /// <returns></returns>
        Task<Intent> GetIntentByDialogflowGeneratedIntentIdAsync(string dialogflowGeneratedIntentId);

        /// <summary>
        /// Get intents async
        /// </summary> 
        Task<Response<IEnumerable<Intent>>> GetIntentsAsync();

        /// <summary>
        /// Update intent async
        /// </summary>
        /// <param name="intent"></param>
        /// <returns></returns>
        Task<Response> UpdateIntentsAsync(Intent intent);
    }
}
