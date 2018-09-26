using HT.Framework;
using HT.Interview.ChatBot.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Common.Contracts
{
    public interface IDashboardService
    {
        Task<Response<IEnumerable<Dashboard>>> GetDashboardData();
    }
}
