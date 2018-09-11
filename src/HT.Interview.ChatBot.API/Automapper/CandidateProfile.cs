using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Request;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Entities;
using Model = HT.Interview.ChatBot.Common.DTO;

namespace HT.Interview.ChatBot.API
{
    /// <inheritdoc />
    /// <summary>
    /// Candidate Profile
    /// </summary>
    public class CandidateProfile : Profile
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public override string ProfileName => "CandidateProfile";

        /// <summary>
        /// Configure auto mapper 
        /// </summary>
        public CandidateProfile()
        { 
            CreateMap<Candidate, CandidateResponse>();
            CreateMap<CandidateRequest, Model.CandidateRequest>();
        }
    }
}
