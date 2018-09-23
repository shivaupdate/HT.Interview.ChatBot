using HT.Framework;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// IInterviewService
    /// </summary>
    public interface IInterviewService
    {
        /// <summary>
        /// Add interview async
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dialogflowGeneratedIntentId"></param>
        /// <returns></returns>
        Task<Response> AddInterviewAsync(int userId, string dialogflowGeneratedIntentId);

        /// <summary>
        /// Update interview async
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dialogflowGeneratedIntentId"></param>
        /// <param name="givenAnswer"></param>
        /// <param name="timeTaken"></param>
        /// <returns></returns>
        Task<Response> UpdateInterviewAsync(int userId, string dialogflowGeneratedIntentId, string givenAnswer, int? timeTaken);
    }
}
