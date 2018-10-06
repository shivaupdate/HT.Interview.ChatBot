using AutoMapper;
using HT.Framework.Contracts;
using HT.Framework.MVC;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.API.DTO.Response.Message;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IUserService _userService;
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
            _userService = factory.GetUserService();
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
            if (q.FirstRequest)
            {
                await _userService.UpdateUserInterviewDateAsync(q.UserId, q.Email);
            }
            if (queryResponse.Result.Metadata.EndConversation)
            {
                await _userService.UpdateUserInterviewCompletedAsync(q.UserId, q.Email);
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

        /// <summary>
        /// Create user async
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost(Common.Constants.UploadVideo), DisableRequestSizeLimit]
        public async Task<ActionResult> CreateUserAsync([FromForm]User user)
        {
            var file = user.RecordingFile;
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\app-data\user\" + user.FirstName + user.LastName);
            if (!(Directory.Exists(path)))
            {
                Directory.CreateDirectory(path);
            } 
            string fileExtension = Path.GetExtension(user.RecordingFile.FileName);
            path = path + @"\" + "Recording_" + user.FirstName + "_" + user.LastName + "_" + fileExtension;
            user.RecordingFilePath = path;
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await user.RecordingFile.CopyToAsync(stream);
            }
            return await GetResponseAsync(async () => (await _userService.UpdateUserRecordingDetailAsync(79, path,"RavindraK@Hexaware.com")));
        }

        #endregion
    }
}
