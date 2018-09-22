using System;
using System.ComponentModel.DataAnnotations;

namespace HT.Interview.ChatBot.Common.Entities
{
    /// <summary>
    /// Job Profile Competence Mapping model
    /// </summary>
    public class JobProfileCompetenceMapping
    {
        /// <summary>
        /// Get or sets the Id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Get or sets the job profile id
        /// </summary>
        /// <value>
        /// The JobProfileId
        /// </value> 
        [Required]
        public int JobProfileId { get; set; }

        /// <summary>
        /// Get or sets the job profile
        /// </summary>
        /// <value>
        /// The JobProfile
        /// </value> 
        [Required]
        public JobProfile JobProfile { get; set; }

        /// <summary>
        /// Get or sets the competence id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 
        [Required]
        public int CompetenceId { get; set; }

        /// <summary>
        /// Get or sets the competence
        /// </summary>
        /// <value>
        /// The Competence
        /// </value> 
        [Required]
        public Competence Competence { get; set; }


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
