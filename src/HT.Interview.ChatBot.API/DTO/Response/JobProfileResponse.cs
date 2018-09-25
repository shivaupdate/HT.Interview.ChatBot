using System;
using System.Collections.Generic;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// JobProfile response
    /// </summary>
    public class JobProfileResponse
    {
        /// <summary>
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value>  
        public int Id { get; set; }

        /// <summary>
        /// Get or sets the Type
        /// </summary>
        /// <value>
        /// The Type
        /// </value>   
        public string Type { get; set; }

        /// <summary>
        /// Get or sets the description
        /// </summary>
        /// <value>
        /// The Description
        /// </value>   
        public string Description { get; set; }

        /// <summary>
        /// Get or sets the min experience
        /// </summary>
        /// <value>
        /// The MinExperience
        /// </value>   
        public int MinExperience { get; set; }

        /// <summary>
        /// Get or sets the max experience
        /// </summary>
        /// <value>
        /// The MaxExperience
        /// </value>   
        public int MaxExperience { get; set; }

        /// <summary>
        /// Get or sets the is active
        /// </summary>
        /// <value>
        /// The IsActive
        /// </value>  
        public bool IsActive { get; set; }

        /// <summary>
        /// Get or sets the CreatedBy
        /// </summary>
        /// <value>
        /// The CreatedBy
        /// </value>  
        public string CreatedBy { get; set; }

        /// <summary>
        /// Get or sets the CreatedOn
        /// </summary>
        /// <value>
        /// The CreatedOn
        /// </value>  
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Get or sets the ModifiedBy
        /// </summary>
        /// <value>
        /// The ModifiedBy
        /// </value> 
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Get or sets the ModifiedOn
        /// </summary>
        /// <value>
        /// The ModifiedOn
        /// </value> 
        public DateTime? ModifiedOn { get; set; } 
    }
}
