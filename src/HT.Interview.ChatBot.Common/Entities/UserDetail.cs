using System;
using System.ComponentModel.DataAnnotations;

namespace HT.Interview.ChatBot.Common.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// User model
    /// </summary>
    public class UserDetail
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
        /// The RoleId
        /// </value> 
        [Required]
        public int RoleId { get; set; }

        /// <summary>
        /// Get or sets the role name
        /// </summary>
        /// <value>
        /// The RoleName
        /// </value> 
        [Required]
        public string RoleName { get; set; }

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
        /// Get or sets the display name
        /// </summary>
        /// <value>
        /// The DisplayName
        /// </value> 
        [Required]
        public string DisplayName { get; set; }

        /// <summary>
        /// Get or sets the gender id
        /// </summary>
        /// <value>
        /// The GenderId
        /// </value> 
        [Required]
        public int GenderId { get; set; }

        /// <summary>
        /// Get or sets the gender name
        /// </summary>
        /// <value>
        /// The GenderName
        /// </value> 
        [Required]
        public string GenderName { get; set; }

        /// <summary>
        /// Get or sets mobile
        /// </summary>
        /// <value>
        /// The Mobile
        /// </value> 
        [Required]
        public string Mobile { get; set; }

        /// <summary>
        /// Get or sets the job profile id
        /// </summary>
        /// <value>
        /// The JobProfileId
        /// </value>  
        public int? JobProfileId { get; set; }

        /// <summary>
        /// Get or sets the job profile type
        /// </summary>
        /// <value>
        /// The JobProfileType
        /// </value>  
        public string JobProfileType { get; set; }
        
        /// <summary>
        /// Get or sets the photo url
        /// </summary>
        /// <value>
        /// The PhotoUrl
        /// </value>  
        public string PhotoUrl { get; set; }

        /// <summary>
        /// Get or sets the provider
        /// </summary>
        /// <value>
        /// The SocialAccouProviderntInfo
        /// </value>  
        public string Provider { get; set; }

        /// <summary>
        /// Get or sets is active
        /// </summary>
        /// <value>
        /// The IsActive
        /// </value> 

        [Required]
        public bool IsActive { get; set; } 
    }
}
