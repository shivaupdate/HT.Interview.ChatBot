using HT.Interview.ChatBot.Common;
using HT.Interview.ChatBot.Common.Entities;
using System;
using static HT.Interview.ChatBot.Common.Enums;


namespace HT.Interview.ChatBot.Common.DTO

{
    /// <summary>
    /// IntentSuggestionRequest
    /// </summary>
    public class IntentSuggestionRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public IntentSuggestionRequest()
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
        /// Get or sets the intent od
        /// </summary>
        /// <value>
        /// The IntentId
        /// </value> 
        
        public int IntentId { get; set; }

        /// <summary>
        /// Get or sets the intent
        /// </summary>
        /// <value>
        /// The Intent
        /// </value> 

        public Intent Intent { get; set; }

        /// <summary>
        /// Get or sets the title
        /// </summary>
        /// <value>
        /// The Title
        /// </value> 
        
        public string Title { get; set; }

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
