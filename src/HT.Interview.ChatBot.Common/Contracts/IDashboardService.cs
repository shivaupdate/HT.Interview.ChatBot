using HT.Framework;
using HT.Interview.ChatBot.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// IDashboardService
    /// </summary>
    public interface IDashboardService
    {
        /// <summary>
        /// Get Dashboard Data
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task<Response<IEnumerable<Dashboard>>> GetDashboardDataAsync();
    }
}
