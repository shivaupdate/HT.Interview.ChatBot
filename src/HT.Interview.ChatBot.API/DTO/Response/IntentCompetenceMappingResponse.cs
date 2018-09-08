using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <inheritdoc />
    /// <summary>
    /// Intent Competence Mapping model
    /// </summary>
    public class IntentCompetenceMappingResponse
    {
        /// <summary>
        /// Get or sets the intent id
        /// </summary>
        /// <value>
        /// The IntentId
        /// </value>  
        public int IntentId { get; set; }

        /// <summary>
        /// Get or sets the competence id
        /// </summary>
        /// <value>
        /// The CompetenceId
        /// </value>  
        public int CompetenceId { get; set; }

        /// <summary>
        /// Get or sets the competence level id
        /// </summary>
        /// <value>
        /// The CompetenceLevelId
        /// </value>  
        public int CompetenceLevelId { get; set; }

        /// <summary>
        /// Get or sets the intent response
        /// </summary>
        /// <value>
        /// The IntentResponse
        /// </value>  
        public IntentResponse IntentResponse { get; set; }
         
        /// <summary>
        /// Get or sets the allocated time
        /// </summary>
        /// <value>
        /// The AllocatedTime
        /// </value>  
        public int AllocatedTime { get; set; }

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
