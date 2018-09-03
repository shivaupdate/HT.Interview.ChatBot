using AutoMapper;
using HT.Framework.Contracts;
using Microsoft.Extensions.Logging;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// IChatBotDataFactory
    /// </summary>
    public interface IChatBotDataFactory
    {
        /// <summary>
        /// Get mapper service
        /// </summary>
        /// <returns></returns>
        IMapper GetMapperService();

        /// <summary>
        /// Get resource service
        /// </summary>
        /// <returns></returns>
        IContentService GetResourceService(string resource);
        
        /// <summary>
        /// Get user service
        /// </summary>
        /// <returns></returns>
        IUserService GetUserService(); 
    }
}
