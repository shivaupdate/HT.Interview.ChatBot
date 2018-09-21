using System;
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
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Get or sets the role id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 
        [Required]
        public int RoleId { get; set; }

        /// <summary>
        /// Get or sets the email
        /// </summary>
        /// <value>
        /// The Email
        /// </value> 
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Get or sets the first name
        /// </summary>
        /// <value>
        /// The FirstName
        /// </value> 
        [Required]
        public string FirstName { get; set; } 

        /// <summary>
        /// Get or sets the last name
        /// </summary>
        /// <value>
        /// The LastName
        /// </value> 
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Get or sets the name
        /// </summary>
        /// <value>
        /// The Name
        /// </value> 
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Get or sets the gender id
        /// </summary>
        /// <value>
        /// The GenderId
        /// </value> 

        [Required]
        public int GenderId { get; set; }

        /// <summary>
        /// Get or sets mobile
        /// </summary>
        /// <value>
        /// The Mobile
        /// </value> 

        [Required]
        public string Mobile { get; set; }

        /// <summary>
        /// Get or sets the photo url
        /// </summary>
        /// <value>
        /// The PhotoUrl
        /// </value>  
        public string PhotoUrl { get; set; }

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
