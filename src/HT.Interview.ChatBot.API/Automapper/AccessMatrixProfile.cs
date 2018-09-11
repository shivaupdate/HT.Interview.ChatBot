using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Entities;
using Model = HT.Interview.ChatBot.Common.DTO;

namespace HT.Interview.ChatBot.API
{
    /// <inheritdoc />
    /// <summary>
    /// AccessMatrix Profile
    /// </summary>
    public class AccessMatrixProfile : Profile
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public override string ProfileName => "AccessMatrixProfile";

        /// <summary>
        /// Configure auto mapper 
        /// </summary>
        public AccessMatrixProfile()
        { 
            CreateMap<AccessMatrix, AccessMatrixResponse>();
            CreateMap<AccessMatrixRequest, Model.AccessMatrixRequest>();


        }
    }
}
