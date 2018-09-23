using HT.Interview.ChatBot.Common;
using HT.Interview.ChatBot.Common.Entities;
using System;
using System.Collections.Generic;
using static HT.Interview.ChatBot.Common.Enums;



namespace HT.Interview.ChatBot.Common.DTO

{
    /// <summary>
    /// IntentRequest
    /// </summary>
    public class IntentRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public IntentRequest()
        { 
            
        }

        /// <summary>
        /// Get or sets the logged in user id
        /// </summary>
        /// <value>
        /// The LoggedInUserId
        /// </value>  
        public string LoggedInUserId { get; set; }

        /// <summary>
        /// Get or sets id
        /// </summary>
        /// <value>
        /// The Id
        /// </value>  
        public int Id { get; set; }

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
