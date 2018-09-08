﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HT.Interview.ChatBot.Common.Entities
{
    public class InterviewTypeCompetenceMapping
    {
        /// <summary>
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 

        [Required]
        public int InterviewTypeId { get; set; }

        /// <summary>
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 

        [Required]
        public int CompetenceId { get; set; }

        /// <summary>
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 

        [Required]
        public string CreatedBy { get; set; }


        /// <summary>
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 

        [Required]
        public DateTime CreatedOn { get; set; }


        /// <summary>
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 

        public string ModifiedBy { get; set; }


        /// <summary>
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 

        public DateTime? ModifiedOn { get; set; }
    }
}
