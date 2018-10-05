using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Entities;

namespace HT.Interview.ChatBot.API
{
    /// <inheritdoc />
    /// <summary>
    /// Gender Profile
    /// </summary>
    public class GenderProfile : Profile
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public override string ProfileName => "GenderProfile";

        /// <summary>
        /// Configure auto mapper 
        /// </summary>
        public GenderProfile()
        { 
            CreateMap<Gender, GenderResponse>(); 
        }
    }
}
