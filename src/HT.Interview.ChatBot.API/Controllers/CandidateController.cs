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
    /// Candidate controller
    /// </summary>
    [Route("api/v1/candidate")]
    public class CandidateController : ApiControllerBase
    {
        #region Fields

        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public CandidateController(IChatBotDataFactory factory)
        {
            _candidateService = factory.GetCandidateService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        public async Task<ActionResult> GetManyAsync([FromQuery] CandidateRequest candidateRequest)
        {
            return await GetResponseAsync(async () => (await _candidateService.GetCandidatesAsync(_mapper.Map<Candidate>(candidateRequest)))
                .GetMappedResponse<IEnumerable<Candidate>, IEnumerable<CandidateResponse>>(_mapper));
        }
         
        #endregion
    }
}
