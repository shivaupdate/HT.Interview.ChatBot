using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <inheritdoc />
    /// <summary>
    /// Intent Training Phrase Response model
    /// </summary>
    public class IntentTrainingPhraseResponse
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
        public IntentResponse IntentResponse { get; set; }

        /// <summary>
        /// Get or sets the Text
        /// </summary>
        /// <value>
        /// The Text
        /// </value>  
        public string Text { get; set; }

        /// <summary>
        /// Get or sets the entity type
        /// </summary>
        /// <value>
        /// The EntityType
        /// </value>  
        public string EntityType { get; set; }

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
