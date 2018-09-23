using HT.Framework;
using HT.Framework.Contracts;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using HT.Interview.ChatBot.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Services
{
    /// <inheritdoc />
    /// <summary>
    /// Job Profile Service
    /// </summary>
    public class JobProfileService : IJobProfileService
    {
        #region Fields

        private readonly IChatBotDataContext _chatbotDataContext;
        private readonly IContentService _resourceService;

        #endregion

        #region Public Functions

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="chatbotDataContext"></param>
        public JobProfileService(IChatBotDataFactory factory, IChatBotDataContext chatbotDataContext)
        {
            _chatbotDataContext = chatbotDataContext;
            _resourceService = factory.GetResourceService(Common.Constants.ResourceComponent);
        }

        #region Get InterviewTypes

        /// <summary>
        /// Get job profiles async
        /// </summary>
        /// <param name="jobProfile"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<JobProfile>>> GetJobProfilesAsync(JobProfile jobProfile)
        {
            IEnumerable<JobProfile> jobProfiles = await _chatbotDataContext.JobProfile.ToListAsync(); 
            return Response.Ok(jobProfiles);
        }

        #endregion

        #endregion
    }
}