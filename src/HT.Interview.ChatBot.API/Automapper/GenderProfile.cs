using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Entities;
using Model = HT.Interview.ChatBot.Common.DTO;

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
            CreateMap<GenderRequest, Model.GenderRequest>();
        }
    }
}
