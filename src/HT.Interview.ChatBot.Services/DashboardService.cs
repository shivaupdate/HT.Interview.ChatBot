﻿using HT.Framework;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.DTO;
using HT.Interview.ChatBot.Common.Entities;
using HT.Interview.ChatBot.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Services
{
    /// <inheritdoc />
    /// <summary>
    /// Dashboard Service
    /// </summary>
    public class DashboardService : IDashboardService
    {
        #region Fields

        private readonly IChatBotDataContext _chatbotDataContext;

        #endregion

        #region Public Functions  

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="chatbotDataContext"></param>
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
        public async Task<Response<List<DashboardResponse>>> GetDashboardDataAsync()
        {
            try
            {
                IEnumerable<Dashboard> dashboard = await _chatbotDataContext.Dashboard.FromSql("icb.usp_DashboardGetReportData_V2").ToListAsync();
                DashboardResponse dashboardResponse = new DashboardResponse();
                IEnumerable<string> chartLabels = dashboard.Select(x => x.InterviewMonth).Distinct();
                dashboardResponse.ChartLabel.AddRange(chartLabels);

                foreach (string technologyStack in dashboard.Select(x => x.TechnologyStackDisplayName).Distinct())
                {
                    ChartDataSet chartDataSet = new ChartDataSet
                    {
                        Label = technologyStack
                    };

                    foreach (string interviewMonth in dashboard.Select(x => x.InterviewMonth).Distinct())
                    {
                        chartDataSet.Data.AddRange
                            (
                                dashboard.Where(x => x.TechnologyStackDisplayName == technologyStack && x.InterviewMonth == interviewMonth)
                                .Select(x => x.MonthlyInterviewCount)
                            );
                    }
                    dashboardResponse.ChartDataSet.Add(chartDataSet);
                }

                return Response.Ok(new List<DashboardResponse> { dashboardResponse });
            }
            catch (Exception)
            {
                return Response.Fail<List<DashboardResponse>>("Something went wrong", ResponseType.GenericError);
            }
        }

        ///// <summary>
        ///// Get Dashboard Data async
        ///// </summary>
        ///// <param name=""></param>
        ///// <param name=""></param>
        ///// <returns></returns>
        //public async Task<Response<List<DashboardData>>> GetDashboardDataAsync()
        //{
        //    try
        //    {
        //        IEnumerable<Dashboard> dashboardData = await _chatbotDataContext.Dashboard.ToListAsync();
        //        List<DashboardData> dashboard = new List<DashboardData>();

        //        foreach (string CompetenceList in dashboardData.Select(x => x.Competence).Distinct())
        //        {
        //            DashboardData obj = new DashboardData
        //            {
        //                label = CompetenceList
        //            };

        //            foreach (Dashboard dasobj in dashboardData.Where(x => x.Competence == CompetenceList))
        //            {
        //                foreach (string month in dashboardData.Select(x => x.Month).Distinct())
        //                {
        //                    if (!dashboardData.Any(x => x.Competence == CompetenceList & x.Month == month))
        //                    {
        //                        obj.data.Add(0);
        //                    }
        //                    else { obj.data.Add(dasobj.Count); break; }


        //                }

        //                //obj.month.Add(dasobj.Month);

        //            }
        //            dashboard.Add(obj);
        //        }
        //        dashboard.FirstOrDefault().month.AddRange(dashboardData.Select(x => x.Month).Distinct());
        //        return Response.Ok(dashboard);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        ex.Message.ToString();
        //        return null;
        //    }
        //}

        #endregion
    }
}
