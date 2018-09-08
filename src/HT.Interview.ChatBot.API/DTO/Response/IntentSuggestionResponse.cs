using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <inheritdoc />
    /// <summary>
    /// Intent Suggestion Response model
    /// </summary>
    public class IntentSuggestionResponse
    {
        /// <summary>
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value>  
        public int Id { get; set; }

        /// <summary>
        /// Get or sets the intent od
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
        public IntentResponse IntentResponse { get; set; }

        /// <summary>
        /// Get or sets the title
        /// </summary>
        /// <value>
        /// The Title
        /// </value>  
        public string Title { get; set; }

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
