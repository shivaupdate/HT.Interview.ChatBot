using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HT.Interview.ChatBot.Common.Entities
{
    public class InterviewTypeCompetenceMapping
    {
        /// <summary>
        /// Get or sets the InterviewTypeId
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 

        [Required]
        public int InterviewTypeId { get; set; }

        /// <summary>
        /// Get or sets the CompetenceId
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 

        [Required]
        public int CompetenceId { get; set; }



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
