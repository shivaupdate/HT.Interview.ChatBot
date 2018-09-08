using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Entities;
using Model = HT.Interview.ChatBot.Common.DTO;

namespace HT.Interview.ChatBot.API
{
    /// <inheritdoc />
    /// <summary>
    /// Attachment Profile
    /// </summary>
    public class AttachmentProfile : Profile
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public override string ProfileName => "AttachmentProfile";

        /// <summary>
        /// Configure auto mapper 
        /// </summary>
        public AttachmentProfile()
        { 
            CreateMap<Attachment, AttachmentResponse>(); 
        }
    }
}
