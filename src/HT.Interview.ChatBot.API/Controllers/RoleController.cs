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
        public async Task<ActionResult> GetManyAsync([FromQuery] int? id, [FromQuery]string name, [FromQuery] string createdyBy)
        {
            return await GetResponseAsync(async () => (await _roleService.GetRolesAsync(id, name, createdyBy))
                .GetMappedResponse<IEnumerable<Role>, IEnumerable<RoleResponse>>(_mapper));
        }

        [HttpPost]
        public async Task<ActionResult> AddRole(Role role)
        {
            return await GetResponseAsync(async () => (await _roleService.AddRoleAsync(role)));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRole(Role role)
        {
            return await GetResponseAsync(async () => (await _roleService.UpdateRoleAsync(role)));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRole(Role role)
        {
            return await GetResponseAsync(async () => (await _roleService.DeleteRoleAsync(role)));
        }
        #endregion
    }
}
