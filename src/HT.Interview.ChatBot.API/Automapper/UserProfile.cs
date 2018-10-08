using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.Common.Entities;

namespace HT.Interview.ChatBot.API
{
    /// <inheritdoc />
    /// <summary>
    /// User Profile
    /// </summary>
    public class UserProfile : Profile
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public override string ProfileName => "UserProfile";

        /// <summary>
        /// Configure auto mapper 
        /// </summary>
        public UserProfile()
        {  
            CreateMap<UserRequest, User>(); 
        }
    }
}
