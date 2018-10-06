using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Entities;

namespace HT.Interview.ChatBot.API.Automapper
{
    public class InterviewDetailProfile : Profile
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public override string ProfileName => "InterviewDetailProfile";

        /// <summary>
        /// Configure auto mapper 
        /// </summary>
        public InterviewDetailProfile()
        {
            CreateMap<InterviewDetail, InterviewDetailResponse>();
        }
    }
}
