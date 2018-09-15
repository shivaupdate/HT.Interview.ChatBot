using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Entities;
using Model = HT.Interview.ChatBot.Common.DTO;

namespace HT.Interview.ChatBot.API
{
    /// <inheritdoc />
    /// <summary>
    /// CompetenceLevel Profile
    /// </summary>
    public class CompetenceLevelProfile : Profile
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public override string ProfileName => "CompetenceLevelProfile";

        /// <summary>
        /// Configure auto mapper 
        /// </summary>
        public CompetenceLevelProfile()
        { 
            CreateMap<CompetenceLevel, CompetenceLevelResponse>();
            CreateMap<CompetenceLevelRequest, Model.CompetenceLevelRequest>();
        }
    }
}
