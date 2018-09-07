using HT.Interview.ChatBot.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace HT.Interview.ChatBot.Data
{
    /// <summary>
    /// IChatbotDataContext
    /// </summary>
    public interface IChatBotDataContext
    {
        /// <summary>
        /// User model
        /// </summary>
        DbSet<User> User { get; set; }

        /// <summary>
        /// Intent model
        /// </summary>
        DbSet<Intent> Intent { get; set; }

        /// <summary>
        /// Intent Suggestion model
        /// </summary>
        DbSet<IntentSuggestion> IntentSuggestion { get; set; }

        /// <summary>
        /// Intent Training Phrase model
        /// </summary>
        DbSet<IntentTrainingPhrase> IntentTrainingPhrase { get; set; }
    }
}
