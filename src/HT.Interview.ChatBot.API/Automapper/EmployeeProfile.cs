using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Entities;
using Model = HT.Interview.ChatBot.Common.DTO;

namespace HT.Interview.ChatBot.API
{
    /// <inheritdoc />
    /// <summary>
    /// Employee Profile
    /// </summary>
    public class EmployeeProfile : Profile
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public override string ProfileName => "EmployeeProfile";

        /// <summary>
        /// Configure auto mapper 
        /// </summary>
        public EmployeeProfile()
        { 
            CreateMap<Employee, EmployeeResponse>(); 
        }
    }
}
