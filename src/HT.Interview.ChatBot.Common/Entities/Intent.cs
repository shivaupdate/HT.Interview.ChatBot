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
        /// Get or sets the JPC mapping id
        /// </summary>
        /// <value>
        /// The JPCMappingId
        /// </value>  
        public int? JPCMappingId { get; set; }

        /// <summary>
        /// Get or sets the parent intent id
        /// </summary>
        /// <value>
        /// The ParentIntentId
        /// </value>  
        public int? ParentIntentId { get; set; }

        /// <summary>
        /// Get or sets the input context
        /// </summary>
        /// <value>
        /// The InputeContext
        /// </value>  
        public string InputContext { get; set; }

        /// <summary>
        /// Get or sets the output context
        /// </summary>
        /// <value>
        /// The OutputContext
        /// </value>  
        public string OutputContext { get; set; }

        /// <summary>
        /// Get or sets the display name
        /// </summary>
        /// <value>
        /// The DisplayName
        /// </value> 
        [Required]
        public string DisplayName { get; set; }
         
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
        /// Get or sets the allocated time
        /// </summary>
        /// <value>
        /// The AllocatedTime
        /// </value> 
        public int AllocatedTime { get; set; }
         
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
        /// Get or sets the dialogflow dialogflow intent id
        /// </summary>
        /// <value>
        /// The DialogflowGeneratedIntentId
        /// </value> 
        public string DialogflowGeneratedIntentId { get; set; }

        /// <summary>
        /// Get or sets the dialogflow generated name
        /// </summary>
        /// <value>
        /// The DialogFlowGeneratedName
        /// </value> 
        public string DialogflowGeneratedName { get; set; }

        /// <summary>
        /// Get or sets the  dialogflow generated intent
        /// </summary>
        /// <value>
        /// The DialogFlowGeneratedIntent
        /// </value>  
        public string DialogflowGeneratedIntent { get; set; }

        /// <summary>
        /// Get or sets the is active
        /// </summary>
        /// <value>
        /// The IsActive
        /// </value> 
        [Required]
        public bool IsActive { get; set; }

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
