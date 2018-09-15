using HT.Interview.ChatBot.Common;
using HT.Interview.ChatBot.Common.Entities;
using System;
using static HT.Interview.ChatBot.Common.Enums;

namespace HT.Interview.ChatBot.Common.DTO
{
    /// <summary>
    /// IntentCompetenceMappingRequest
    /// </summary>
    public class IntentCompetenceMappingRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public IntentCompetenceMappingRequest()
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
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
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
        /// Get or sets the competence id
        /// </summary>
        /// <value>
        /// The CompetenceId
        /// </value> 
        
        public int CompetenceId { get; set; }

        /// <summary>
        /// Get or sets the competence level id
        /// </summary>
        /// <value>
        /// The CompetenceLevelId
        /// </value>  
        public int CompetenceLevelId { get; set; }

        /// <summary>
        /// Get or sets the allocated time
        /// </summary>
        /// <value>
        /// The AllocatedTime
        /// </value> 
        
        public int AllocatedTime { get; set; }

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
