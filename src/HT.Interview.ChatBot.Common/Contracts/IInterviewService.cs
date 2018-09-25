﻿using HT.Framework;
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
        /// <param name="botResponse"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        Task<Response> AddInterviewAsync(int userId, string dialogflowGeneratedIntentId, string botResponse, string createdBy);

        /// <summary>
        /// Update interview async
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dialogflowGeneratedIntentId"></param>
        /// <param name="userResponse"></param>
        /// <param name="timeTaken"></param>
        /// <param name="modifiedBy"></param>
        /// <returns></returns>
        Task<Response> UpdateInterviewAsync(int userId, string dialogflowGeneratedIntentId, string userResponse, int? timeTaken, string modifiedBy);
    }
}
