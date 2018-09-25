using System;
using System.ComponentModel.DataAnnotations;

namespace HT.Interview.ChatBot.Common.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Interview model
    /// </summary>
    public class Interview
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
        /// Get or sets the user id
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>  
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Get or sets the intent id
        /// </summary>
        /// <value>
        /// The IntentId
        /// </value>  
        public int? IntentId { get; set; }

        /// <summary>
        /// Get or sets the bot response
        /// </summary>
        /// <value>
        /// The BotResponse
        /// </value>   
        public string BotResponse { get; set; }

        /// <summary>
        /// Get or sets the user response
        /// </summary>
        /// <value>
        /// The UserResponse
        /// </value>   
        public string UserResponse { get; set; }

        /// <summary>
        /// Get or sets the timen taken
        /// </summary>
        /// <value>
        /// The TimeTaken
        /// </value>  
        public int? TimeTaken { get; set; }
          
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
