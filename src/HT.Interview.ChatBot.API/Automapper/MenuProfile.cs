using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Entities;
using Model = HT.Interview.ChatBot.Common.DTO;

namespace HT.Interview.ChatBot.API
{
    /// <inheritdoc />
    /// <summary>
    /// Menu Profile
    /// </summary>
    public class MenuProfile : Profile
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public override string ProfileName => "MenuProfile";

        /// <summary>
        /// Configure auto mapper 
        /// </summary>
        public MenuProfile()
        { 
            CreateMap<Menu, MenuResponse>(); 
        }
    }
}
