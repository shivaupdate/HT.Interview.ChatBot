using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        /// The RoleId
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
        /// Get or sets the job profile id
        /// </summary>
        /// <value>
        /// The JobProfileId
        /// </value>  
        public int? JobProfileId { get; set; }

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
        /// Get or sets is interview completed
        /// </summary>
        /// <value>
        /// The IsInterviewCompleted
        /// </value>  
        [Required]
        public bool IsInterviewCompleted { get; set; }

        /// <summary>
        /// Get or sets is active
        /// </summary>
        /// <value>
        /// The IsActive
        /// </value>  
        [Required]
        public bool IsActive { get; set; }

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

        /// <summary>
        /// Get or sets the resume file
        /// </summary>
        /// <value>
        /// The ResumeFile
        /// </value> 
        [NotMapped]
        public IFormFile ResumeFile { get; set; }

        /// <summary>
        /// Get or sets the Recording file
        /// </summary>
        /// <value>
        /// The ResumeFile
        /// </value> 
        [NotMapped]
        public IFormFile RecordingFile { get; set; }
    }
}
