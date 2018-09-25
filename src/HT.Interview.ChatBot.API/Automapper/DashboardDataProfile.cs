using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Entities;

namespace HT.Interview.ChatBot.API.Automapper
{
    public class DashboardDataProfile : Profile
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public override string ProfileName => "DashboardDataProfile";

        /// <summary>
        /// Configure auto mapper 
        /// </summary>
        public DashboardDataProfile()
        {
            CreateMap<DashboardData, DashboardDataResponse>();
        }
    }
}
