using AutoMapper;
using HT.Framework.MVC;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = HT.Interview.ChatBot.Common.DTO;

namespace HT.Interview.ChatBot.API.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// InterviewTypeCompetenceMapping controller
    /// </summary>
    [Route("api/v1/InterviewTypeCompetenceMapping")]
    public class InterviewTypeCompetenceMappingController : ApiControllerBase
    {
        #region Fields

        private readonly IInterviewTypeCompetenceMappingService _interviewTypeCompetenceMappingService;
        private readonly IMapper _mapper;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public InterviewTypeCompetenceMappingController(IChatBotDataFactory factory)
        {
            _interviewTypeCompetenceMappingService = factory.GetInterviewTypeCompetenceMappingService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        public async Task<ActionResult> GetManyAsync([FromQuery] int interviewTypeId,  [FromQuery]int competenceId, [FromQuery] string createdBy)
        {
            return await GetResponseAsync(async () => (await _interviewTypeCompetenceMappingService.GetInterviewTypeCompetenceMappingsAsync(interviewTypeId, competenceId, createdBy))
                .GetMappedResponse<IEnumerable<InterviewTypeCompetenceMapping>, IEnumerable<InterviewTypeCompetenceMappingResponse>>(_mapper));
        }
         
        #endregion
    }
}
