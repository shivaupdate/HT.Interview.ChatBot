﻿using AutoMapper;
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
        /// Get intent service
        /// </summary>
        /// <returns></returns>
        public IIntentService GetIntentService()
        {
            return _dependencyResolver.Resolve<IIntentService>();
        }

        /// <inheritdoc />
        /// <summary>
        /// Get role service
        /// </summary>
        /// <returns></returns>
        public IRoleService GetRoleService()
        {
            return _dependencyResolver.Resolve<IRoleService>();
        }
         

        /// <inheritdoc />
        /// <summary>
        /// Get Menu service
        /// </summary>
        /// <returns></returns>
        public IMenuService GetMenuService()
        {
            return _dependencyResolver.Resolve<IMenuService>();
        }



        /// <inheritdoc />
        /// <summary>
        /// Get InterviewTypeCompetenceMapping service
        /// </summary>
        /// <returns></returns>
        public IInterviewTypeCompetenceMappingService GetInterviewTypeCompetenceMappingService()
        {
            return _dependencyResolver.Resolve<IInterviewTypeCompetenceMappingService>();
        }



        /// <inheritdoc />
        /// <summary>
        /// Get InterviewType service
        /// </summary>
        /// <returns></returns>
        public IInterviewTypeService GetInterviewTypeService()
        {
            return _dependencyResolver.Resolve<IInterviewTypeService>();
        }
          
        /// <inheritdoc />
        /// <summary>
        /// Get Gender service
        /// </summary>
        /// <returns></returns>
        public IGenderService GetGenderService()
        {
            return _dependencyResolver.Resolve<IGenderService>();
        }
         
        /// <inheritdoc />
        /// <summary>
        /// Get Employee service
        /// </summary>
        /// <returns></returns>
        public IEmployeeService GetEmployeeService()
        {
            return _dependencyResolver.Resolve<IEmployeeService>();
        }
         
        /// <inheritdoc />
        /// <summary>
        /// Get CompetenceLevel service
        /// </summary>
        /// <returns></returns>
        public ICompetenceLevelService GetCompetenceLevelService()
        {
            return _dependencyResolver.Resolve<ICompetenceLevelService>();
        } 

        /// <inheritdoc />
        /// <summary>
        /// Get Competence service
        /// </summary>
        /// <returns></returns>
        public ICompetenceService GetCompetenceService()
        {
            return _dependencyResolver.Resolve<ICompetenceService>();
        }
         
        /// <inheritdoc />
        /// <summary>
        /// Get Candidate service
        /// </summary>
        /// <returns></returns>
        public ICandidateService GetCandidateService()
        {
            return _dependencyResolver.Resolve<ICandidateService>();
        }
         
        /// <inheritdoc />
        /// <summary>
        /// Get Attachment service
        /// </summary>
        /// <returns></returns>
        public IAttachmentService GetAttachmentService()
        {
            return _dependencyResolver.Resolve<IAttachmentService>();
        }
         
        /// <inheritdoc />
        /// <summary>
        /// Get AccessMatrix service
        /// </summary>
        /// <returns></returns>
        public IAccessMatrixService GetAccessMatrixService()
        {
            return _dependencyResolver.Resolve<IAccessMatrixService>();
        } 
    }
}
