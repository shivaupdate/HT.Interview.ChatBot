using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HT.Framework.Contracts;
using HT.Interview.ChatBot.Common.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HT.Framework.MVC;
using HT.Interview.ChatBot.Common.Entities;

namespace HT.Interview.ChatBot.API.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Dashboard Controller
    /// </summary>
    [Route("api/v1/dashboard")]
    public class DashboardController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHttpClient _httpClient;
        private readonly IDashboardService _dashboardDataService;

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public DashboardController(IChatBotDataFactory factory)
        {
            _httpClient = factory.GetHttpClient();
            _mapper = factory.GetMapperService();
            _dashboardDataService = factory.GetDashboardService();
        }

        /// <summary>
        /// Get Dashboard Data Async
        /// </summary>
        /// <param name=""></param>
        /// <returns>Dashboard Data Collection for graph</returns>
        [HttpGet(Common.Constants.Get)]
        public async Task<ActionResult> GetDashboardDataAsync()
        { 
            return await GetResponseAsync(async () => (await _dashboardDataService.GetDashboardDataAsync())
                .GetMappedResponse<IEnumerable<Dashboard>, IEnumerable<Dashboard>>(_mapper));
        }
    }
}