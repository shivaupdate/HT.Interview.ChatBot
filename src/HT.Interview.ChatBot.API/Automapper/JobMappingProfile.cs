using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Entities;

namespace HT.Interview.ChatBot.API
{
    /// <inheritdoc />
    /// <summary>
    /// Job Profile
    /// </summary>
    public class JobMappingProfile : Profile
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public override string ProfileName => "JobMappingProfile";

        /// <summary>
        /// Configure auto mapper 
        /// </summary>
        public JobMappingProfile()
        { 
            CreateMap<JobProfile, JobProfileResponse>(); 
        }
    }
}
