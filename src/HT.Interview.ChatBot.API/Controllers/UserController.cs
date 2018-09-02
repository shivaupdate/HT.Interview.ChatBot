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
    /// UserController
    /// </summary>
    [Route("api/v2/user")]
    [Produces("application/json")]
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
        /// Get User Groups Async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        [Produces(typeof(IEnumerable<UserResponse>))]
        public async Task<ActionResult> GetManyAsync([FromQuery] UserQuery uc)
        {
            return await GetResponseAsync(async () =>
            {
                return Pageable<UserResponse>.Paginate((await _userService.GetUsersAsync(_mapper.Map<Model.UserQuery>(uc)))
                .GetMappedResponse<IEnumerable<User>, IEnumerable<UserResponse>>(_mapper), uc.CurrentPage, uc.PageSize);
            }); 
        }

        #endregion
    }
}
