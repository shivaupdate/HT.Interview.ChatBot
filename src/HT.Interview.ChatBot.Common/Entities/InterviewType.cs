using System;
using System.ComponentModel.DataAnnotations;

namespace HT.Interview.ChatBot.Common.Entities
{
    public class InterviewType
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
        /// Get or sets the Type
        /// </summary>
        /// <value>
        /// The Type
        /// </value> 

        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Get or sets the description
        /// </summary>
        /// <value>
        /// The Description
        /// </value> 

        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Get or sets the CreatedBy
        /// </summary>
        /// <value>
        /// The CreatedBy
        /// </value> 

        [Required]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Get or sets the CreatedOn
        /// </summary>
        /// <value>
        /// The CreatedOn
        /// </value> 
        [Required]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Get or sets the ModifiedBy
        /// </summary>
        /// <value>
        /// The ModifiedBy
        /// </value> 
        public string ModifiedBy { get; set; }


        /// <summary>
        /// Get or sets the ModifiedOn
        /// </summary>
        /// <value>
        /// The ModifiedOn
        /// </value> 
        public DateTime? ModifiedOn { get; set; }
    }
}
