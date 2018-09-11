using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Entities;
using Model = HT.Interview.ChatBot.Common.DTO;

namespace HT.Interview.ChatBot.API
{
    /// <inheritdoc />
    /// <summary>
    /// Role profile
    /// </summary>
    public class RoleProfile : Profile
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public override string ProfileName => "RoleProfile";

        /// <summary>
        /// Configure auto mapper 
        /// </summary>
        public RoleProfile()
        { 
            CreateMap<Role, RoleResponse>();            
            CreateMap<RoleRequest, Model.RoleRequest>();
        }
    }
}
