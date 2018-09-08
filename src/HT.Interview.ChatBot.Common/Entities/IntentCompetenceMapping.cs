using System;
using System.ComponentModel.DataAnnotations;

namespace HT.Interview.ChatBot.Common.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Intent Competence Mapping model
    /// </summary>
    public class IntentCompetenceMapping
    {
        /// <summary>
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 
        [Required]
        public int IntentId { get; set; }

        /// <summary>
        /// Get or sets the intent
        /// </summary>
        /// <value>
        /// The Intent
        /// </value> 
        [Required]
        public Intent Intent { get; set; }

        /// <summary>
        /// Get or sets the competence id
        /// </summary>
        /// <value>
        /// The CompetenceId
        /// </value> 
        [Required]
        public int CompetenceId { get; set; }
         
        /// <summary>
        /// Get or sets the competence level id
        /// </summary>
        /// <value>
        /// The CompetenceLevelId
        /// </value>  
        [Required]
        public int CompetenceLevelId { get; set; }
         
        /// <summary>
        /// Get or sets the allocated time
        /// </summary>
        /// <value>
        /// The AllocatedTime
        /// </value> 
        [Required]
        public int AllocatedTime { get; set; }
         
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
