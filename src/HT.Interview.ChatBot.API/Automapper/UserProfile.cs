using AutoMapper;
using HT.Interview.ChatBot.API.DTO;
using HT.Interview.ChatBot.Common.Entities;
using Model = HT.Interview.ChatBot.Common.DTO;

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
            CreateMap<UserResponse, User>();
            CreateMap<User, UserResponse>();
            CreateMap<UserQuery, Model.UserQuery>();
            CreateMap<Model.UserQuery, UserQuery>();
        }
    }
}
