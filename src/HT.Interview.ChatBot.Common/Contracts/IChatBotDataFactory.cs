using AutoMapper;
using HT.Framework.Contracts;
using HT.Framework.MVC;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// IChatBotDataFactory
    /// </summary>
    public interface IChatBotDataFactory
    {
        /// <summary>
        /// Get Api Ai settings
        /// </summary>
        /// <returns></returns>
        ApiAiSettings GetApiAiSettings();

        /// <summary>
        /// Get Http client
        /// </summary>
        /// <returns></returns>
        IHttpClient GetHttpClient();

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
