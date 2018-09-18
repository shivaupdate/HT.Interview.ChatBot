using AutoMapper;
using HT.Framework.MVC;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors("InterviewChatBot")]
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
        /// <returns></returns>
        //[HttpGet(Common.Constants.GetMany)]
        //public async Task<ActionResult> GetManyAsync([FromQuery] Candidate candidate)
        //{
        //    return await GetResponseAsync(async () => (await _candidateService.GetCandidatesAsync(candidate))
        //        .GetMappedResponse<IEnumerable<Candidate>, IEnumerable<CandidateResponse>>(_mapper));
        //}

        [HttpGet(Common.Constants.Get)]
        public async Task<ActionResult> GetManyAsync()
        {
            return await GetResponseAsync(async () => (await _candidateService.GetCandidatesAsync())
                .GetMappedResponse<IEnumerable<Candidate>, IEnumerable<CandidateResponse>>(_mapper));
        }

        [HttpPost]
        public async Task<ActionResult> AddCandidate([FromBody]Candidate candidate)
        {
            return await GetResponseAsync(async () => (await _candidateService.AddCandidateAsync(candidate)));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCandidate([FromBody]Candidate candidate)
        {
            return await GetResponseAsync(async () => (await _candidateService.UpdateCandidateAsync(candidate)));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCandidate([FromBody]Candidate candidate)
        {
            return await GetResponseAsync(async () => (await _candidateService.DeleteCandidateAsync(candidate)));
        }
        #endregion
    }
}