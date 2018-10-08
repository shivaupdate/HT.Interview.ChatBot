using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Entities;

namespace HT.Interview.ChatBot.API
{
    /// <inheritdoc />
    /// <summary>
    /// Competence Profile
    /// </summary>
    public class CompetenceProfile : Profile
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public override string ProfileName => "CompetenceProfile";

        /// <summary>
        /// Configure auto mapper 
        /// </summary>
        public CompetenceProfile()
        { 
            CreateMap<Competence, CompetenceResponse>(); 
        }
    }
}
