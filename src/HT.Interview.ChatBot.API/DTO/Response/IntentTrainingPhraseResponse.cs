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
        /// The FirstName
        /// </value>  
        public int IntentId { get; set; }

        /// <summary>
        /// Get or sets the intent
        /// </summary>
        /// <value>
        /// The FirstName
        /// </value>  
        public IntentResponse Intent { get; set; }

        /// <summary>
        /// Get or sets the title
        /// </summary>
        /// <value>
        /// The Email
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
