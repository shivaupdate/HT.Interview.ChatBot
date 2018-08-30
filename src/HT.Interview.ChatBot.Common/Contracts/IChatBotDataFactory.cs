using HT.Interview.ChatBot.Common.Contracts;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// IMasterDataFactory
    /// </summary>
    public interface IChatBotDataFactory
    { 
        /// <summary>
        /// Get user service
        /// </summary>
        /// <returns></returns>
        IUserService GetUserService(); 
    }
}
