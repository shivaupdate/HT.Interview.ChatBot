using AutoMapper;
using HT.Framework.MVC;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.API.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// User Controller
    /// </summary>
    [Route("api/v1/user")] 
    public class UserController : ApiControllerBase
    {
        #region Fields

        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public UserController(IChatBotDataFactory factory)
        {
            _userService = factory.GetUserService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        ///  Get user by email async
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet(Common.Constants.Get)]
        public async Task<ActionResult> GetUserByEmailAsync([FromQuery] string email)
        {
            return await GetResponseAsync(async () => (await _userService.GetUserByEmailAsync(email))
                .GetMappedResponse<User, UserResponse>(_mapper));
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <param name="ud"></param>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)] 
        public async Task<ActionResult> GetManyAsync([FromQuery] UserDetail ud)
        {
            return await GetResponseAsync(async () => (await _userService.GetUsersAsync(_mapper.Map<UserDetail>(ud)))
                .GetMappedResponse<IEnumerable<UserDetail>, IEnumerable<UserDetail>>(_mapper));
        }

        /// <summary>
        /// Get many by role id async
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetManyByRoleId)]
        public async Task<ActionResult> GetManyByRoleIdAsync([FromQuery] int roleId)
        { 
            return await GetResponseAsync(async () => (await _userService.GetUsersByRoleIdAsync(roleId))
                .GetMappedResponse<IEnumerable<UserDetail>, IEnumerable<UserDetail>>(_mapper));
        }

        /// <summary>
        /// Create user async
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost(Common.Constants.Create)]
        public async Task<ActionResult> CreateUserAsync([FromForm]User user)
        { 
            return await GetResponseAsync(async () => (await _userService.CreateUserAsync(user)));
        }
         
        /// <summary>
        /// Update user async
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut(Common.Constants.Update)]
        public async Task<ActionResult> UpdateUserAsync([FromBody]User user)
        {
            return await GetResponseAsync(async () => (await _userService.UpdateUserAsync(user)));
        }

        /// <summary>
        /// Delete user async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Common.Constants.Delete)]
        public async Task<ActionResult> DeleteUserAsync([FromQuery] int id)
        {
            return await GetResponseAsync(async () => (await _userService.DeleteUserAsync(id)));
        }

        #endregion
    }
}
