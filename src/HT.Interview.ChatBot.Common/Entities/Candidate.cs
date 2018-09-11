using System;
using System.ComponentModel.DataAnnotations;

namespace HT.Interview.ChatBot.Common.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Candidate model
    /// </summary>
    public class Candidate
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
        /// Get or sets the first name
        /// </summary>
        /// <value>
        /// The FirstName
        /// </value> 
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Get or sets the LastName
        /// </summary>
        /// <value>
        /// The LastName
        /// </value> 

        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Get or sets the Email
        /// </summary>
        /// <value>
        /// The Email
        /// </value> 

        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Get or sets the GenderId
        /// </summary>
        /// <value>
        /// The GenderId
        /// </value> 

        [Required]
        public int GenderId { get; set; }

        /// <summary>
        /// Get or sets the Mobile
        /// </summary>
        /// <value>
        /// The Mobile
        /// </value> 

        [Required]
        public string Mobile { get; set; }

        /// <summary>
        /// Get or sets the CreatedBy
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
