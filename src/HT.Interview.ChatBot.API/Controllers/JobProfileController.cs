using AutoMapper;
using HT.Framework.MVC;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.API.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// InterviewType controller
    /// </summary>
    [Route("api/v1/jobprofile")]
    public class JobProfileController : ApiControllerBase
    {
        #region Fields

        private readonly IJobProfileService _jobProfileService;
        private readonly IMapper _mapper;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public JobProfileController(IChatBotDataFactory factory)
        {
            _jobProfileService = factory.GetJobProfileService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        public async Task<ActionResult> GetManyAsync()
        {
            return await GetResponseAsync(async () => (await _jobProfileService.GetJobProfilesAsync(new JobProfile()))
                .GetMappedResponse<IEnumerable<JobProfile>, IEnumerable<JobProfileResponse>>(_mapper));
        }

        #endregion
    }
}
