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
    /// Dialogflow Controller
    /// </summary>
    [Route("api/v1/dialogflow")]
    public class DialogflowController : ApiControllerBase
    {
        #region Fields

        private readonly IDialogflowService _dialogflowService;
        private readonly IMapper _mapper;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public DialogflowController(IChatBotDataFactory factory)
        {
            _dialogflowService = factory.GetDialogflowService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        public async Task<ActionResult> GetManyAsync()
        {
            return await GetResponseAsync(async () => (await _dialogflowService.GetIntentsAsync())
                .GetMappedResponse<IEnumerable<Intent>, IEnumerable<IntentResponse>>(_mapper)); 
        }

        #endregion
    }
}
