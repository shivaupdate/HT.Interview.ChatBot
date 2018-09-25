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
    /// Role controller
    /// </summary>
    [Route("api/v1/role")]
    public class RoleController : ApiControllerBase
    {
        #region Fields

        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public RoleController(IChatBotDataFactory factory)
        {
            _roleService = factory.GetRoleService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        public async Task<ActionResult> GetManyAsync()
        {
            return await GetResponseAsync(async () => (await _roleService.GetRolesAsync())
                .GetMappedResponse<IEnumerable<Role>, IEnumerable<RoleResponse>>(_mapper));
        }

        /// <summary>
        /// Get many by role id async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetManyByRoleId)]
        public async Task<ActionResult> GetManyByRoleIdAsync([FromQuery]int roleId)
        {
            return await GetResponseAsync(async () => (await _roleService.GetRoleClaimDetailByRoleIdAsync(roleId))
                .GetMappedResponse<IEnumerable<RoleClaimDetail>, IEnumerable<RoleClaimDetail>>(_mapper));
        }

        #endregion
    }
}
