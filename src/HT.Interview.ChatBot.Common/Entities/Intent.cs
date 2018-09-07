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
        /// Get or sets the competence id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 
        [Required]
        public int? CompetenceId { get; set; }

        /// <summary>
        /// Get or sets the competence level id
        /// </summary>
        /// <value>
        /// The Id
        /// </value>  
        public int? CompetenceLevelId { get; set; }


        /// <summary>
        /// Get or sets the display name
        /// </summary>
        /// <value>
        /// The CreatedBy
        /// </value> 
        [Required]
        public string DisplayName { get; set; }

        /// <summary>
        /// Get or sets the text
        /// </summary>
        /// <value>
        /// The CreatedBy
        /// </value> 
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// Get or sets the allocated time
        /// </summary>
        /// <value>
        /// The CreatedBy
        /// </value> 
        [Required]
        public int AllocatedTime { get; set; }

        /// <summary>
        /// Get or sets the intent training phrase
        /// </summary>
        /// <value>
        /// The CreatedBy
        /// </value> 
        public ICollection<IntentTrainingPhrase> IntentTrainingPhrase { get; set; }

        /// <summary>
        /// Get or sets the intent suggestion
        /// </summary>
        /// <value>
        /// The CreatedBy
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
