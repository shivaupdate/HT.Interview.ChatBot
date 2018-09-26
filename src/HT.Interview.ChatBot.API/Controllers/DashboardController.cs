﻿using System;
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
    [Route("api/v1/dashboard")]
    [ApiController]
    public class DashboardController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHttpClient _httpClient;
        private readonly IDashboardService _dashboardDataService;

        public DashboardController(IChatBotDataFactory factory)
        {
            _httpClient = factory.GetHttpClient();
            _mapper = factory.GetMapperService();
            _dashboardDataService = factory.GetDashboardService();
        }

        [HttpGet(Common.Constants.Get)]
        public async Task<ActionResult> GetDashboardData()
        { 
            return await GetResponseAsync(async () => (await _dashboardDataService.GetDashboardData())
                .GetMappedResponse<IEnumerable<Dashboard>, IEnumerable<Dashboard>>(_mapper));
        }
    }
}