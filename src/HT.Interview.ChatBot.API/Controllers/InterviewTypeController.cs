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
    /// InterviewType controller
    /// </summary>
    [Route("api/v1/interviewType")]
    public class InterviewTypeController : ApiControllerBase
    {
        #region Fields

        private readonly IInterviewTypeService _interviewTypeService;
        private readonly IMapper _mapper;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public InterviewTypeController(IChatBotDataFactory factory)
        {
            _interviewTypeService = factory.GetInterviewTypeService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        public async Task<ActionResult> GetManyAsync([FromQuery] int? id, [FromQuery]string type, [FromQuery] string createdyBy)
        {
            return await GetResponseAsync(async () => (await _interviewTypeService.GetInterviewTypesAsync(id, type, createdyBy))
                .GetMappedResponse<IEnumerable<InterviewType>, IEnumerable<InterviewTypeResponse>>(_mapper));
        }
         
        #endregion
    }
}
