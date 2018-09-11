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
        /// <param name="candidateId"></param>
        /// <param name="dialogflowGeneratedIntentId"></param>
        /// <returns></returns>
        Task<Response> AddInterviewAsync(int candidateId, string dialogflowGeneratedIntentId);

        /// <summary>
        /// Update interview async
        /// </summary>
        /// <param name="candidateId"></param>
        /// <param name="dialogflowGeneratedIntentId"></param>
        /// <param name="givenAnswer"></param>
        /// <param name="timeTaken"></param>
        /// <returns></returns>
        Task<Response> UpdateInterviewAsync(int candidateId, string dialogflowGeneratedIntentId, string givenAnswer, int? timeTaken);
    }
}
