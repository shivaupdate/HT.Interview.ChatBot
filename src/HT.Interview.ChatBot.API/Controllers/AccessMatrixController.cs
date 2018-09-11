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
    /// AccessMatrix controller
    /// </summary>
    [Route("api/v1/accessMatrix")]
    public class AccessMatrixController : ApiControllerBase
    {
        #region Fields

        private readonly IAccessMatrixService _accessMatrixService;
        private readonly IMapper _mapper;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public AccessMatrixController(IChatBotDataFactory factory)
        {
            _accessMatrixService = factory.GetAccessMatrixService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        public async Task<ActionResult> GetManyAsync([FromQuery] AccessMatrix accessMatrix)
        {
            return await GetResponseAsync(async () => (await _accessMatrixService.GetAccessMatrixsAsync(accessMatrix))
                .GetMappedResponse<IEnumerable<AccessMatrix>, IEnumerable<AccessMatrixResponse>>(_mapper));
        }

        [HttpPost]
        public async Task<ActionResult> AddAccessMatrix(AccessMatrix accessMatrix)
        {
            return await GetResponseAsync(async () => (await _accessMatrixService.AddAccessMatrixAsync(accessMatrix)));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAccessMatrix(AccessMatrix accessMatrix)
        {
            return await GetResponseAsync(async () => (await _accessMatrixService.UpdateAccessMatrixAsync(accessMatrix)));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAccessMatrix(AccessMatrix accessMatrix)
        {
            return await GetResponseAsync(async () => (await _accessMatrixService.DeleteAccessMatrixAsync(accessMatrix)));
        }
        #endregion
    }
}