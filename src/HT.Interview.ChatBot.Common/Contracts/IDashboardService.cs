using HT.Framework;
using HT.Interview.ChatBot.Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    /// <summary>
    /// Dashboard service
    /// </summary>
    public interface IDashboardService
    {
        /// <summary>
        /// Get Dashboard data async
        /// </summary>
        /// <returns></returns>
        Task<Response<List<DashboardResponse>>> GetDashboardDataAsync(); 
    }
}
