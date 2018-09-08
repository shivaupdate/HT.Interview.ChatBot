using System;
using System.Collections.Generic;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// Intent Response
    /// </summary>
    public class IntentResponse
    {
        /// <summary>
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 
        public int Id { get; set; }

        /// <summary>
        /// Get or sets the competence id
        /// </summary>
        /// <value>
        /// The CompetenceId
        /// </value> 
        public int? CompetenceId { get; set; }

        /// <summary>
        /// Get or sets the competence level id
        /// </summary>
        /// <value>
        /// The CompetenceLevelId
        /// </value>  
        public int? CompetenceLevelId { get; set; }

        /// <summary>
        /// Get or sets the display name
        /// </summary>
        /// <value>
        /// The DisplayName
        /// </value> 
        public string DisplayName { get; set; }

        /// <summary>
        /// Get or sets the text
        /// </summary>
        /// <value>
        /// The Text
        /// </value> 
        public string Text { get; set; }

        /// <summary>
        /// Get or sets the allocated time
        /// </summary>
        /// <value>
        /// The AllocatedTime
        /// </value> 
        public int AllocatedTime { get; set; }

        /// <summary>
        /// Get or sets the intent compentence mapping response
        /// </summary>
        /// <value>
        /// The IntentCompetenceMappingResponse
        /// </value> 
        public ICollection<IntentCompetenceMappingResponse> IntentCompetenceMappingResponse { get; set; }

        /// <summary>
        /// Get or sets the intent training phrase response
        /// </summary>
        /// <value>
        /// The IntentTrainingPhraseResponse
        /// </value> 
        public ICollection<IntentTrainingPhraseResponse> IntentTrainingPhraseResponse { get; set; }

        /// <summary>
        /// Get or sets the intent parameter response
        /// </summary>
        /// <value>
        /// The IntentParameterResponse
        /// </value> 
        public ICollection<IntentParameterResponse> IntentParameterResponse { get; set; }

        /// <summary>
        /// Get or sets the intent suggestion response
        /// </summary>
        /// <value>
        /// The IntentSuggestionResponse
        /// </value> 
        public ICollection<IntentSuggestionResponse> IntentSuggestionResponse { get; set; }

        /// <summary>
        /// Get or sets the created by
        /// </summary>
        /// <value>
        /// The CreatedBy
        /// </value> 
        public string CreatedBy { get; set; }

        /// <summary>
        /// Get or sets the created on
        /// </summary>
        /// <value>
        /// The CreatedOn
        /// </value> 
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Get or sets the modified by
        /// </summary>
        /// <value>
        /// The ModifiedBy
        /// </value>  
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Get or sets the modified on
        /// </summary>
        /// <value>
        /// The ModifiedOn
        /// </value>  
        public DateTime? ModifiedOn { get; set; }

    }
}
