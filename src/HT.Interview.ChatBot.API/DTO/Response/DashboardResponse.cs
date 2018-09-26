using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    public class DashboardResponse
    {
        public class DashboardData
        {
            public int Id { get; set; }
            public int Year { get; set; }
            public string Month { get; set; }
            public string Competence { get; set; }
            public int Count { get; set; }
        }
    }
}
