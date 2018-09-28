using AutoMapper;
using HT.Framework.Contracts;
using HT.Framework.MVC;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.API.DTO.Response.Message;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.API.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Intent Controller
    /// </summary>
    [Route("api/v1/interview")]
    public class InterviewController : ApiControllerBase
    {
        #region Fields

        private readonly IInterviewService _interviewService;
        private readonly IMapper _mapper;
        private readonly IHttpClient _httpClient;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public InterviewController(IChatBotDataFactory factory)
        {
            _httpClient = factory.GetHttpClient();
            _interviewService = factory.GetInterviewService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        /// Get async
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        [HttpGet(Common.Constants.Get)]
        public async Task<ActionResult> GetAsync([FromQuery] QueryRequest q)
        {
            if (!string.IsNullOrWhiteSpace(q.DialogflowGeneratedIntentId))
            {
                await _interviewService.UpdateResponseAsync(q.UserId, q.DialogflowGeneratedIntentId, q.Query.FirstOrDefault(), q.TimeTaken, q.Email);
            }

            QueryResponse queryResponse = await _httpClient.GetAsync<QueryResponse>(q.ToQueryString());
            queryResponse.Result.DialogflowGeneratedIntentId = queryResponse.Result.Metadata.IntentId;
            if (!string.IsNullOrWhiteSpace(queryResponse.Result.DialogflowGeneratedIntentId))
            {
                string botResponse = string.Empty;
                try
                {
                    botResponse = ((SimpleResponse)queryResponse.Result.Fulfillment.Messages[0]).TextToSpeech;
                }
                catch
                {
                }
                await _interviewService.AddResponseAsync(q.UserId, queryResponse.Result.DialogflowGeneratedIntentId, botResponse, q.Email);
            }

            return await GetResponseAsync(async () => await Task.FromResult(queryResponse));
        }

        /// <summary>
        /// Get interview details by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetInterviewDetailByUserId)]
        public async Task<ActionResult> GetInterviewDetail(int userId)
        {
            return await GetResponseAsync(async () => (await _interviewService.GetInterviewDetail(userId))
            .GetMappedResponse<IEnumerable<InterviewDetail>, IEnumerable<InterviewDetail>>(_mapper));
        }

        #endregion
    }
}
