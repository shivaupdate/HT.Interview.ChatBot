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
        public int Id { get; set; }

        /// <summary>
        /// Get or sets the role id
        /// </summary>
        /// <value>
        /// The RoleId
        /// </value>  
        public int RoleId { get; set; }

        /// <summary>
        /// Get or sets the role name
        /// </summary>
        /// <value>
        /// The RoleName
        /// </value>  
        public string RoleName { get; set; }

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
        /// Get or sets the display name
        /// </summary>
        /// <value>
        /// The DisplayName
        /// </value>  
        public string DisplayName { get; set; }

        /// <summary>
        /// Get or sets the gender id
        /// </summary>
        /// <value>
        /// The GenderId
        /// </value>  
        public int GenderId { get; set; }

        /// <summary>
        /// Get or sets the gender name
        /// </summary>
        /// <value>
        /// The GenderName
        /// </value>  
        public string GenderName { get; set; }

        /// <summary>
        /// Get or sets mobile
        /// </summary>
        /// <value>
        /// The Mobile
        /// </value>  
        public string Mobile { get; set; }

        /// <summary>
        /// Get or sets the job profile id
        /// </summary>
        /// <value>
        /// The JobProfileId
        /// </value>  
        public int? JobProfileId { get; set; }

        /// <summary>
        /// Get or sets the profile name
        /// </summary>
        /// <value>
        /// The ProfileName
        /// </value>  
        public string ProfileName { get; set; }

        /// <summary>
        /// Get or sets the technology stack name
        /// </summary>
        /// <value>
        /// The TechnologyStackName
        /// </value>  
        public string TechnologyStackName { get; set; }

        /// <summary>
        /// Get or sets the technology stack display name
        /// </summary>
        /// <value>
        /// The TechnologyStackDisplayName
        /// </value>  
        public string TechnologyStackDisplayName { get; set; }
         
        /// <summary>
        /// Get or sets the interview date
        /// </summary>
        /// <value>
        /// The InterviewDate
        /// </value>  
        public DateTime? InterviewDate { get; set; }

        /// <summary>
        /// Get or sets the remark
        /// </summary>
        /// <value>
        /// The Remark
        /// </value>  
        public string Remark { get; set; }

        /// <summary>
        /// Get or sets the end result
        /// </summary>
        /// <value>
        /// The EndResult
        /// </value>  
        public string EndResult { get; set; }

        /// <summary>
        /// Get or sets the resume file path
        /// </summary>
        /// <value>
        /// The ResumeFilePath
        /// </value>  
        public string ResumeFilePath { get; set; }

        /// <summary>
        /// Get or sets the recording file path
        /// </summary>
        /// <value>
        /// The RecordingFilePath
        /// </value>  
        public string RecordingFilePath { get; set; }

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
        public bool IsActive { get; set; } 
    }
}
