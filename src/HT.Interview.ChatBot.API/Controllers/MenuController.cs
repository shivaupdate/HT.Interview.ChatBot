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
    /// Menu controller
    /// </summary>
    [Route("api/v1/menu")]
    public class MenuController : ApiControllerBase
    {
        #region Fields

        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public MenuController(IChatBotDataFactory factory)
        {
            _menuService = factory.GetMenuService();
            _mapper = factory.GetMapperService();
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        public async Task<ActionResult> GetManyAsync()
        {
            return await GetResponseAsync(async () => (await _menuService.GetMenusAsync())
                .GetMappedResponse<IEnumerable<Menu>, IEnumerable<MenuResponse>>(_mapper));
        }

        #endregion
    }
}
