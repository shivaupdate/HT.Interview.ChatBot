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
    public class DashboardService : IDashboardService
    {
        private readonly IChatBotDataContext _chatbotDataContext;

        public DashboardService(IChatBotDataFactory factory, IChatBotDataContext chatbotDataContext)
        {
            _chatbotDataContext = chatbotDataContext;
        }

        /// <summary>
        /// Get Dashboard Data async
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<Response<List<DashboardData>>> GetDashboardData()
        {
            try
            {
                IEnumerable<Dashboard> dashboardData = await _chatbotDataContext.DashboardData.ToListAsync();
                List<DashboardData> dashboard = new List<DashboardData>();
 
                foreach (string CompetenceList in dashboardData.Select(x => x.Competence).Distinct())
                {
                    DashboardData obj = new DashboardData();
                    obj.label = CompetenceList;

                    foreach (Dashboard dasobj in dashboardData.Where(x => x.Competence == CompetenceList))
                    {
                        foreach(string month in dashboardData.Select(x => x.Month).Distinct())
                        {
                            if(!dashboardData.Any(x => x.Competence == CompetenceList & x.Month == month))
                            {
                                obj.data.Add(0);
                            }
                            else { obj.data.Add(dasobj.Count);break; }
                           

                        }
                    
                        //obj.month.Add(dasobj.Month);

                    }
                    dashboard.Add(obj);
                }
                dashboard.FirstOrDefault().month.AddRange(dashboardData.Select(x => x.Month).Distinct());
                return Response.Ok(dashboard);
            }
            catch (System.Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }
    }
}
