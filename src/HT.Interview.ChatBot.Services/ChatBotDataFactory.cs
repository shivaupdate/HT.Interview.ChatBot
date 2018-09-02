﻿using HT.Framework.Contracts;
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

        public IContentService GetResourceService(string name)
        {
            return _dependencyResolver.Resolve<IContentService>();
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
    }
}
