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
    /// Attachment controller
    /// </summary>
    [Route("api/v1/attachment")]
    public class AttachmentController : ApiControllerBase
    {
        #region Fields

        private readonly IAttachmentService _attachmentService;
        private readonly IMapper _mapper;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public AttachmentController(IChatBotDataFactory factory)
        {
            _attachmentService = factory.GetAttachmentService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        public async Task<ActionResult> GetManyAsync([FromQuery] Attachment attachment)
        {
            return await GetResponseAsync(async () => (await _attachmentService.GetAttachmentsAsync(attachment))
                .GetMappedResponse<IEnumerable<Attachment>, IEnumerable<AttachmentResponse>>(_mapper));
        }
         
        #endregion
    }
}
