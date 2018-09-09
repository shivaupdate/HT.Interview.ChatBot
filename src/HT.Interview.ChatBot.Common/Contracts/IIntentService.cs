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
        /// Get intents async
        /// </summary> 
        Task<Response<IEnumerable<Intent>>> GetIntentsAsync();
    }
}
