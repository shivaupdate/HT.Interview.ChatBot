using AutoMapper;
using HT.Framework.MVC;
using HT.Interview.ChatBot.API.DTO;
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
    /// User controller
    /// </summary>
    [Route("api/v2/user")]
    [Produces("application/json")]
    public class UserController : ApiControllerBase
    {
        #region Fields

        private readonly IUserService _userService;

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
        }

        /// <summary>
        /// Get User Groups Async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        [Produces(typeof(IEnumerable<UserResponse>))]
        //[SwaggerOperation(Common.Constants.GetMany)]
        public async Task<ActionResult> GetManyAsync([FromQuery] UserQuery uc)
        {
            //return await GetResponseAsync(async () => (await _userService.GetUsersAsync(new Model.UserQuery()))
            //.GetMappedResponse<IEnumerable<User>, IEnumerable<UserResponse>>());

            return await GetResponseAsync(async () => (await _userService.GetUsersAsync(new Model.UserQuery())));
        }

        #endregion
    }
}
