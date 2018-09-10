using AutoMapper;
using HT.Framework.Contracts;
using HT.Framework.MVC;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.API.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Intent Controller
    /// </summary>
    [Route("api/v1/interview")]
    [EnableCors("InterviewChatBot")]
    public class InterviewController : ApiControllerBase
    {
        #region Fields

        private readonly IIntentService _intentService;
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
            _intentService = factory.GetIntentService();
            _mapper = factory.GetMapperService();
        }

        ///// <summary>
        ///// Get many async
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet(Common.Constants.Get)]
        //public async Task<ActionResult> GetAsync([FromQuery] string text)
        //{
        //    // return await GetResponseAsync(async () => await _httpClient.GetAsync<QueryResponse>(q.ToQueryString()));
        //    // string projectId = "ht-interview-chatbot";
        //    // string sessionId = "1";
        //    // string languageCode = "en-US";

        //    // SessionsClient client = SessionsClient.Create();
        //    // var result = (await client.DetectIntentAsync(
        //    //    session: new SessionName(projectId, sessionId),
        //    //    queryInput: new QueryInput()
        //    //    {
        //    //        Text = new TextInput()
        //    //        {
        //    //            Text = text,
        //    //            LanguageCode = languageCode
        //    //        }
        //    //    }
        //    //));

        //    // return await GetResponseAsync(async () => await Task.FromResult(result.QueryResult));
        //    return null;
        //}

        /// <summary>
        /// Get async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.Get)]
        public async Task<ActionResult> GetAsync([FromQuery] string query)
        {
            QueryRequest q = new QueryRequest()
            {
                Query = new string[]{ query },
                SessionId = "1",
                Lang = Common.Enums.Language.English
            };


            return await GetResponseAsync(async () => await _httpClient.GetAsync<QueryResponse>(q.ToQueryString()));
        }

        #endregion
    }
}
