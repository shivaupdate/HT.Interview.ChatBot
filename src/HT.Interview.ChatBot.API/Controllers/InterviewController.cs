using AutoMapper;
using Google.Cloud.Dialogflow.V2;
using HT.Framework.MVC;
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

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public InterviewController(IChatBotDataFactory factory)
        {
            _intentService = factory.GetIntentService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.Get)]
        public async Task<ActionResult> GetAsync([FromQuery] string text)
        { 
            string projectId = "ht-interview-chatbot";
            string sessionId = "1";
            string languageCode = "en-US";

            SessionsClient client = SessionsClient.Create();
            var result = (await client.DetectIntentAsync(
               session: new SessionName(projectId, sessionId),
               queryInput: new QueryInput()
               {
                   Text = new TextInput()
                   {
                       Text = text,
                       LanguageCode = languageCode
                   }
               }
           ));

            return await GetResponseAsync(async () => await Task.FromResult(result));
        }


        #endregion
    }
}
