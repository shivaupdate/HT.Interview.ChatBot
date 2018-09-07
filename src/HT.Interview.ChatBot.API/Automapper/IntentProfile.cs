﻿using AutoMapper;
using HT.Interview.ChatBot.API.DTO.Response;
using HT.Interview.ChatBot.Common.Entities;

namespace HT.Interview.ChatBot.API
{
    /// <inheritdoc />
    /// <summary>
    /// Intent Profile
    /// </summary>
    public class IntentProfile : Profile
    {
        /// <summary>
        /// Profile name
        /// </summary>
        public override string ProfileName => "IntentProfile";

        /// <summary>
        /// Configure auto mapper 
        /// </summary>
        public IntentProfile()
        {
            CreateMap<Intent, IntentResponse>()
                .ForMember(dest => dest.IntentTrainingPhraseResponse, opt => opt.MapFrom(src => src.IntentTrainingPhrase))
                .ForMember(dest => dest.IntentSuggestionResponse, opt => opt.MapFrom(src => src.IntentSuggestion));
            CreateMap<IntentTrainingPhrase, IntentTrainingPhraseResponse>();
            CreateMap<IntentSuggestion, IntentSuggestionResponse>();
        }
    }
}
