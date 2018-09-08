using System;
using System.ComponentModel.DataAnnotations;

namespace HT.Interview.ChatBot.Common.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Intent Training Phrase model
    /// </summary>
    public class IntentTrainingPhrase
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
        /// Get or sets the intent id
        /// </summary>
        /// <value>
        /// The IntentId
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
        /// Get or sets the text
        /// </summary>
        /// <value>
        /// The Text
        /// </value> 
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// Get or sets the entity type
        /// </summary>
        /// <value>
        /// The EntityType
        /// </value>  
        public string EntityType { get; set; }

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
