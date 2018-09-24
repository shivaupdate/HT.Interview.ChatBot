using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HT.Interview.ChatBot.Common.Entities
{
    /// <summary>
    /// Job Profile model
    /// </summary>
    public class JobProfile
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
        /// Get or sets the technology stack id
        /// </summary>
        /// <value>
        /// The TechnologyStackId
        /// </value>  
        [Required]
        public int TechnologyStackId { get; set; }

        /// <summary>
        /// Get or sets the profile name
        /// </summary>
        /// <value>
        /// The ProfileName
        /// </value>  
        [Required]
        public string ProfileName { get; set; }

        /// <summary>
        /// Get or sets the description
        /// </summary>
        /// <value>
        /// The Description
        /// </value>  
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Get or sets the min experience
        /// </summary>
        /// <value>
        /// The MinExperience
        /// </value>  
        [Required]
        public int MinExperience { get; set; }

        /// <summary>
        /// Get or sets the max experience
        /// </summary>
        /// <value>
        /// The MaxExperience
        /// </value>  
        [Required]
        public int MaxExperience { get; set; }

        /// <summary>
        /// Get or sets the is active
        /// </summary>
        /// <value>
        /// The IsActive
        /// </value> 
        [Required]
        public bool IsActive { get; set; }

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

        /// <summary>
        /// Get or sets the job profile competence mapping
        /// </summary>
        /// <value>
        /// The JobProfileCompetenceMapping
        /// </value> 
        public ICollection<JobProfileCompetenceMapping> JobProfileCompetenceMapping { get; set; }

    }
}
