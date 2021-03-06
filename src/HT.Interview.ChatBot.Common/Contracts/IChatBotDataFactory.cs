﻿using AutoMapper;
using HT.Framework.Contracts;
using HT.Framework.MVC;

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

        /// <summary>
        /// Get intent service
        /// </summary>
        /// <returns></returns>
        IIntentService GetIntentService();

        /// <summary>
        /// Get role service
        /// </summary>
        /// <returns></returns>
        IRoleService GetRoleService();

        /// <summary>
        /// Get Job Profile service
        /// </summary>
        /// <returns></returns>
        IJobProfileService GetJobProfileService();
                 
        /// <summary>
        /// Get Gender service
        /// </summary>
        /// <returns></returns>
        IGenderService GetGenderService();
         
        /// <summary>
        /// Get Competence service
        /// </summary>
        /// <returns></returns>
        ICompetenceService GetCompetenceService();
            
        /// <summary>
        /// Get interview service
        /// </summary>
        /// <returns></returns>
        IInterviewService GetInterviewService();

        /// <summary>
        /// Get GetDashboard service
        /// </summary>
        /// <returns></returns>
        IDashboardService GetDashboardService();
    }
}
