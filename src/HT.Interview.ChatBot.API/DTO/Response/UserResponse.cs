using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// UserResponse
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value>  
        public int Id { get; set; }

        /// <summary>
        /// Get or sets the role id
        /// </summary>
        /// <value>
        /// The Id
        /// </value>  
        public int RoleId { get; set; }

        /// <summary>
        /// Get or sets the email
        /// </summary>
        /// <value>
        /// The Email
        /// </value>  
        public string Email { get; set; }

        /// <summary>
        /// Get or sets the first name
        /// </summary>
        /// <value>
        /// The FirstName
        /// </value>  
        public string FirstName { get; set; }

        /// <summary>
        /// Get or sets the last name
        /// </summary>
        /// <value>
        /// The LastName
        /// </value>  
        public string LastName { get; set; }
         
        /// <summary>
        /// Get or sets the gender id
        /// </summary>
        /// <value>
        /// The GenderId
        /// </value>  
        public int GenderId { get; set; }

        /// <summary>
        /// Get or sets mobile
        /// </summary>
        /// <value>
        /// The Mobile
        /// </value>  
        public string Mobile { get; set; }


        /// <summary>
        /// Get or sets the social account info
        /// </summary>
        /// <value>
        /// The SocialAccountInfo
        /// </value>  
        public string SocialAccountInfo { get; set; }

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
        /// Get or sets is resume file path
        /// </summary>
        /// <value>
        /// The ResumeFilePath
        /// </value>  
        public string ResumeFilePath { get; set; }

        /// <summary>
        /// Get or sets is recording file path
        /// </summary>
        /// <value>
        /// The RecordingFilePath
        /// </value>  
        public string RecordingFilePath { get; set; }

        /// <summary>
        /// Get or sets is active
        /// </summary>
        /// <value>
        /// The IsActive
        /// </value>  
        public bool IsActive { get; set; }

        /// <summary>
        /// Get or sets the created by
        /// </summary>
        /// <value>
        /// The CreatedBy
        /// </value>  
        public string CreatedBy { get; set; }

        /// <summary>
        /// Get or sets the created on
        /// </summary>
        /// <value>
        /// The CreatedOn
        /// </value>  
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
