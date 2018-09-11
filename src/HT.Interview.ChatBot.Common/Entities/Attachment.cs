using System;
using System.ComponentModel.DataAnnotations;

namespace HT.Interview.ChatBot.Common.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Attachment model
    /// </summary>
    public class Attachment
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
        /// Get or sets the CandidateId
        /// </summary>
        /// <value>
        /// The FirstName
        /// </value> 
        [Required]


        public int CandidateId { get; set; }

        /// <summary>
        /// Get or sets the ResumeFilePath
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 

        [Required]


        public string ResumeFilePath { get; set; }

        /// <summary>
        /// Get or sets the GestureRecordingFilePath
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 

        [Required]

        public string GestureRecordingFilePath { get; set; }
        


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
