using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <inheritdoc />
    /// <summary>
    /// Intent model
    /// </summary>
    public class IntentOutputContextResponse
    {
        /// <summary>
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value>  
        public int Id { get; set; }

        /// <summary>
        /// Get or sets the intent id
        /// </summary>
        /// <value>
        /// The IntentId
        /// </value>  
        public int IntentId { get; set; }

        /// <summary>
        /// Get or sets the intent response
        /// </summary>
        /// <value>
        /// The IntentResponse
        /// </value>  
        public IntentResponse Intent { get; set; }

        /// <summary>
        /// Get or sets the lifespan count
        /// </summary>
        /// <value>
        /// The LifespanCount
        /// </value>  
        public int LifespanCount { get; set; }

        /// <summary>
        /// Get or sets the name
        /// </summary>
        /// <value>
        /// The Name
        /// </value>  
        public string Name { get; set; }

        /// <summary>
        /// Get or sets the parameters
        /// </summary>
        /// <value>
        /// The Parameters
        /// </value>  
        public string Parameters { get; set; }

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
