using HT.Interview.ChatBot.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace HT.Interview.ChatBot.Data
{
    /// <summary>
    /// IChatbotDataContext
    /// </summary>
    internal interface IChatbotDataContext
    {
        /// <summary>
        /// User model
        /// </summary>
        DbSet<User> User { get; set; } 
    }
}
