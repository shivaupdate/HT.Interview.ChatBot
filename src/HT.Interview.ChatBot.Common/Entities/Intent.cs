using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HT.Interview.ChatBot.Common.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Intent model
    /// </summary>
    public class Intent
    {
        /// <summary>
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 
        [Required]
        public int Id { get; set; }
         
        /// <summary>
        /// Get or sets the display name
        /// </summary>
        /// <value>
        /// The DisplayName
        /// </value> 
        [Required]
        public string DisplayName { get; set; }

        /// <summary>
        /// Get or sets the input context names
        /// </summary>
        /// <value>
        /// The InputContextNames
        /// </value>  
        public string InputContextNames { get; set; }

        /// <summary>
        /// Get or sets the text
        /// </summary>
        /// <value>
        /// The Text
        /// </value> 
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// Get or sets the expected answer
        /// </summary>
        /// <value>
        /// The ExpectedAnswer
        /// </value>  
        public string ExpectedAnswer { get; set; }

        /// <summary>
        /// Get or sets the intent ouput context
        /// </summary>
        /// <value>
        /// The IntentOutputContext
        /// </value> 
        public ICollection<IntentOutputContext> IntentOutputContext { get; set; }

        /// <summary>
        /// Get or sets the intent competence mapping
        /// </summary>
        /// <value>
        /// The IntentCompetenceMapping
        /// </value> 
        public ICollection<IntentCompetenceMapping> IntentCompetenceMapping { get; set; }

        /// <summary>
        /// Get or sets the intent training phrase
        /// </summary>
        /// <value>
        /// The IntentTrainingPhrase
        /// </value> 
        public ICollection<IntentTrainingPhrase> IntentTrainingPhrase { get; set; }

        /// <summary>
        /// Get or sets the intent parameter
        /// </summary>
        /// <value>
        /// The IntentParameter
        /// </value> 
        public ICollection<IntentParameter> IntentParameter { get; set; }

        /// <summary>
        /// Get or sets the intent suggestion
        /// </summary>
        /// <value>
        /// The IntentSuggestion
        /// </value> 
        public ICollection<IntentSuggestion> IntentSuggestion { get; set; }

        /// <summary>
        /// Get or sets the created by
        /// </summary>
        /// <value>
        /// The CreatedBy
        /// </value> 
        [Required]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Get or sets the created on
        /// </summary>
        /// <value>
        /// The CreatedOn
        /// </value> 
        [Required]
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
