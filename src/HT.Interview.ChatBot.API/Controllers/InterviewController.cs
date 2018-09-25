using AutoMapper;
using HT.Framework.Contracts;
using HT.Framework.MVC;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Contracts;
using Microsoft.AspNetCore.Mvc;
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
                await _interviewService.UpdateInterviewAsync(q.UserId, q.DialogflowGeneratedIntentId, q.Query.FirstOrDefault(), q.TimeTaken, q.Email);
            }

            QueryResponse queryResponse = await _httpClient.GetAsync<QueryResponse>(q.ToQueryString());
            queryResponse.Result.DialogflowGeneratedIntentId = queryResponse.Result.Metadata.IntentId;
            if (!string.IsNullOrWhiteSpace(queryResponse.Result.DialogflowGeneratedIntentId))
            {
                await _interviewService.AddInterviewAsync(q.UserId, queryResponse.Result.DialogflowGeneratedIntentId, q.Query.FirstOrDefault(), q.Email);
            }

            return await GetResponseAsync(async () => await Task.FromResult(queryResponse));
        }

        [HttpGet(Common.Constants.InterviewDetail)]
        public async Task<ActionResult> GetInterviewDetail(int candidateId)
        {
            return await GetResponseAsync(async () => await Task.FromResult(_interviewService.GetInterviewDetail(candidateId)));
        }
        #endregion
    }
}
