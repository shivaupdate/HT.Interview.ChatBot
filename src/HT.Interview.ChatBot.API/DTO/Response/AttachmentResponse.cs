using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// Attachment response
    /// </summary>
    public class AttachmentResponse
    {
        /// <summary>
        /// Get or sets the Id
        /// </summary>
        /// <value>
        /// The Id
        /// </value>  
        public int Id { get; set; }
        /// <summary>
        /// Get or sets the CandidateId
        /// </summary>
        /// <value>
        /// The CandidateId
        /// </value>  

        public int CandidateId { get; set; }

        /// <summary>
        /// Get or sets the ResumeFilePath
        /// </summary>
        /// <value>
        /// The ResumeFilePath
        /// </value>  

        public string ResumeFilePath { get; set; }

        /// <summary>
        /// Get or sets the GestureRecordingFilePath
        /// </summary>
        /// <value>
        /// The GestureRecordingFilePath
        /// </value>  
        public string GestureRecordingFilePath { get; set; }




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
