using System;
using System.ComponentModel.DataAnnotations;

namespace HT.Interview.ChatBot.Common.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Intent Parameter model
    /// </summary>
    public class IntentParameter
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
        /// Get or sets the mandatory
        /// </summary>
        /// <value>
        /// The Mandatory
        /// </value> 
        [Required]
        public bool Mandatory { get; set; }

        /// <summary>
        /// Get or sets the display name
        /// </summary>
        /// <value>
        /// The DisplayName
        /// </value> 
        [Required]
        public string DisplayName { get; set; }

        /// <summary>
        /// Get or sets the entity type display name
        /// </summary>
        /// <value>
        /// The EntityTypeDisplayName
        /// </value> 
        [Required]
        public string EntityTypeDisplayName { get; set; }

        /// <summary>
        /// Get or sets the value
        /// </summary>
        /// <value>
        /// The Value
        /// </value> 
        [Required]
        public string Value { get; set; }

        /// <summary>
        /// Get or sets the IsList
        /// </summary>
        /// <value>
        /// The Email
        /// </value> 
        [Required]
        public bool IsList { get; set; }

        /// <summary>
        /// Get or sets the IsList
        /// </summary>
        /// <value>
        /// The Email
        /// </value>  
        public string Prompt { get; set; }

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
