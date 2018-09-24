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
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        public async Task<ActionResult> GetManyAsync([FromQuery] int roleId)
        {
            return await GetResponseAsync(async () => (await _accessMatrixService.GetAccessMatrixByRoleIdAsync(roleId))
                .GetMappedResponse<IEnumerable<AccessMatrix>, IEnumerable<AccessMatrixResponse>>(_mapper));
        } 
        #endregion
    }
}