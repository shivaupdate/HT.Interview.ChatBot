using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Entities;
using Model = HT.Interview.ChatBot.Common.DTO;

namespace HT.Interview.ChatBot.API
{
    /// <inheritdoc />
    /// <summary>
    /// InterviewTypeCompetenceMapping Profile
    /// </summary>
    public class InterviewTypeCompetenceMappingProfile : Profile
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public override string ProfileName => "InterviewTypeCompetenceMappingProfile";

        /// <summary>
        /// Configure auto mapper 
        /// </summary>
        public InterviewTypeCompetenceMappingProfile()
        { 
            CreateMap<InterviewTypeCompetenceMapping, InterviewTypeCompetenceMappingResponse>(); 
        }
    }
}
