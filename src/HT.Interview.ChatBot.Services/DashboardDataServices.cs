using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HT.Framework;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using HT.Interview.ChatBot.Data;
using System.Linq;
using HT.Framework.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HT.Interview.ChatBot.Services
{
    public class DashboardDataServices : IDashboardDataService
    {
        private readonly IChatBotDataContext _chatbotDataContext;

        public DashboardDataServices(IChatBotDataFactory factory, IChatBotDataContext chatbotDataContext)
        {
            _chatbotDataContext = chatbotDataContext;
        }

        /// <summary>
        /// Get Dashboard Data async
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<DashboardData>>> GetDashboardData()
        {
            try
            {
                IEnumerable<DashboardData> dashboardData = await _chatbotDataContext.DashboardData.ToListAsync();
                return Response.Ok(dashboardData);
            }
            catch (System.Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }
    }
}
