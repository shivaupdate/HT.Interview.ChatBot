using AutoMapper;
using HT.Framework.Contracts;
using HT.Framework.MVC;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common;
using HT.Interview.ChatBot.Common.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.API.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// UserController
    /// </summary>
    [Route("api/v1/apiai")]
    [Produces("application/json")]
    public class ApiAiController : ApiControllerBase
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IHttpClient _httpClient;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public ApiAiController(IChatBotDataFactory factory)
        {
            _httpClient = factory.GetHttpClient();
            _mapper = factory.GetMapperService();
        }


        /// <summary>
        /// Get async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.Get)]
        public async Task<ActionResult> GetAsync([FromQuery] QueryRequest q)
        { 
            return await GetResponseAsync(async () => await _httpClient.GetAsync<QueryResponse>(q.ToQueryString()));
        }

        #endregion
    }
}
