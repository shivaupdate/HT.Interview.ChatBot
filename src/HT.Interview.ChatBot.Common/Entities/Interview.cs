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
        /// Get or sets the interview type id
        /// </summary>
        /// <value>
        /// The InterviewTypeId
        /// </value>  
        [Required]
        public int InterviewTypeId { get; set; }

        
        /// <summary>
        /// Get or sets the candidate id
        /// </summary>
        /// <value>
        /// The CandidateId
        /// </value>  
        [Required]
        public int CandidateId { get; set; }

        /// <summary>
        /// Get or sets the intent id
        /// </summary>
        /// <value>
        /// The IntentId
        /// </value>  
        [Required]
        public int IntentId { get; set; }

        /// <summary>
        /// Get or sets the output context
        /// </summary>
        /// <value>
        /// The OutputContext
        /// </value>  
        [Required]
        public string GivenAnswer { get; set; }

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
