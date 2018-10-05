using AutoMapper;
using HT.Framework.MVC; 
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.DTO;
using HT.Interview.ChatBot.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.API.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Dashboard Controller
    /// </summary>
    [Route("api/v1/dashboard")]
    public class DashboardController : ApiControllerBase
    {
        #region Fields

        private readonly IMapper _mapper; 
        private readonly IDashboardService _dashboardDataService;

        #endregion

        #region Public Functions

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public DashboardController(IChatBotDataFactory factory)
        { 
            _mapper = factory.GetMapperService();
            _dashboardDataService = factory.GetDashboardService();
        }

        /// <summary>
        /// Get many async
        /// </summary>
        /// <returns></returns>
        [HttpGet(Common.Constants.GetMany)]
        public async Task<ActionResult> GetDashboardDataAsync()
        {
            return await GetResponseAsync(async () => (await _dashboardDataService.GetDashboardDataAsync())
                .GetMappedResponse<List<DashboardResponse>, List<DashboardResponse>>(_mapper)); 
        }

        #endregion
    }
}