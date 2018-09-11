using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Entities;
using Model = HT.Interview.ChatBot.Common.DTO;

namespace HT.Interview.ChatBot.API
{
    /// <inheritdoc />
    /// <summary>
    /// InterviewType Profile
    /// </summary>
    public class InterviewTypeProfile : Profile
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public override string ProfileName => "InterviewTypeProfile";

        /// <summary>
        /// Configure auto mapper 
        /// </summary>
        public InterviewTypeProfile()
        { 
            CreateMap<InterviewType, InterviewTypeResponse>();
            CreateMap<InterviewTypeRequest, Model.InterviewTypeRequest>();
        }
    }
}
