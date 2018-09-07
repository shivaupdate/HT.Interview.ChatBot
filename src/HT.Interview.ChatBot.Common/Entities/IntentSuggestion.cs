using System;
using System.ComponentModel.DataAnnotations;

namespace HT.Interview.ChatBot.Common.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Intent Suggestion model
    /// </summary>
    public class IntentSuggestion
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
        /// Get or sets the intent od
        /// </summary>
        /// <value>
        /// The FirstName
        /// </value> 
        [Required]
        public int IntentId { get; set; }

        /// <summary>
        /// Get or sets the intent
        /// </summary>
        /// <value>
        /// The FirstName
        /// </value> 
        [Required]
        public Intent Intent { get; set; }

        /// <summary>
        /// Get or sets the title
        /// </summary>
        /// <value>
        /// The Email
        /// </value> 
        [Required]
        public string Title { get; set; }

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
