using System.ComponentModel.DataAnnotations;

namespace HT.Interview.ChatBot.Common.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// User model
    /// </summary>
    public class User 
    {
        /// <summary>
        /// Get or Sets the User Claim Id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 
        [Required]
        public int Id { get; set; } 
    }
}
