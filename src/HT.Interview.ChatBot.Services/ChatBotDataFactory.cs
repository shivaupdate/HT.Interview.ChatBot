using AutoMapper;
using HT.Framework.Contracts;
using HT.Framework.MVC;
using HT.Interview.ChatBot.Common.Contracts;

namespace HT.Interview.ChatBot.Services
{
    /// <inheritdoc />
    /// <summary>
    /// Chat bot data factory
    /// </summary>
    public class ChatBotDataFactory : IChatBotDataFactory
    {
        private readonly IDependencyResolver _dependencyResolver;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dependencyResolver"></param>
        public ChatBotDataFactory(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        /// <summary>
        /// Get Api Ai settings
        /// </summary>
        /// <returns></returns>
        public ApiAiSettings GetApiAiSettings()
        {
            return _dependencyResolver.Resolve<ApiAiSettings>();
        }

        /// <summary>
        /// Get Http client
        /// </summary>
        /// <returns></returns>
        public IHttpClient GetHttpClient()
        {
            return _dependencyResolver.Resolve<IHttpClient>();
        }

        /// <summary>
        /// Get mapper service
        /// </summary>
        /// <returns></returns>
        public IMapper GetMapperService()
        {
            return _dependencyResolver.Resolve<IMapper>();
        }

        /// <summary>
        /// Get resource service
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IContentService GetResourceService(string name)
        {
            return _dependencyResolver.Resolve<IContentService>(name);
        }

        /// <inheritdoc />
        /// <summary>
        /// Get user service
        /// </summary>
        /// <returns></returns>
        public IUserService GetUserService()
        {
            return _dependencyResolver.Resolve<IUserService>();
        }

        /// <inheritdoc />
        /// <summary>
        /// Get dialogflow service
        /// </summary>
        /// <returns></returns>
        public IDialogflowService GetDialogflowService()
        {
            return _dependencyResolver.Resolve<IDialogflowService>();
        }        
    }
}
