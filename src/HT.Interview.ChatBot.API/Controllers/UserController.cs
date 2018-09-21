using AutoMapper;
using HT.Framework.MVC;
using HT.Interview.ChatBot.API.DTO.Request;
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
        /// Get many async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)] 
        public async Task<ActionResult> GetManyAsync([FromQuery] UserRequest u)
        {
            return await GetResponseAsync(async () => (await _userService.GetUsersAsync(_mapper.Map<User>(u)))
                .GetMappedResponse<IEnumerable<User>, IEnumerable<UserResponse>>(_mapper));
        }

        /// <summary>
        /// Get many as pageable async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetManyAsPageable)] 
        public async Task<ActionResult> GetManyAsPageableAsync([FromQuery] UserRequest u)
        {
            return await GetResponseAsync(async () =>
            {
                return Pageable<UserResponse>.Paginate((await _userService.GetUsersAsync(_mapper.Map<User>(u)))
                .GetMappedResponse<IEnumerable<User>, IEnumerable<UserResponse>>(_mapper), u.CurrentPage, u.PageSize);
            });
        }
         
        /// <summary>
        /// Create user async
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost(Common.Constants.Create)]
        public async Task<ActionResult> AddCandidateAsync([FromBody]User user)
        {
            return await GetResponseAsync(async () => (await _userService.CreateUserAsync(user)));
        }

        /// <summary>
        /// Update user async
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut(Common.Constants.Update)]
        public async Task<ActionResult> UpdateCandidateAsync([FromBody]User user)
        {
            return await GetResponseAsync(async () => (await _userService.UpdateUserAsync(user)));
        }

        /// <summary>
        /// Delete user async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Common.Constants.Delete)]
        public async Task<ActionResult> DeleteCandidateAsync([FromQuery] int id)
        {
            return await GetResponseAsync(async () => (await _userService.DeleteUserAsync(id)));
        }

        #endregion
    }
}
