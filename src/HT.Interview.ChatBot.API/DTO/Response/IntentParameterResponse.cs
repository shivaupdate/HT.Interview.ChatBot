using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <inheritdoc />
    /// <summary>
    /// Intent Parameter model
    /// </summary>
    public class IntentParameterResponse
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
        /// Get or sets the mandatory
        /// </summary>
        /// <value>
        /// The Mandatory
        /// </value>  
        public bool Mandatory { get; set; }

        /// <summary>
        /// Get or sets the display name
        /// </summary>
        /// <value>
        /// The DisplayName
        /// </value>  
        public string DisplayName { get; set; }

        /// <summary>
        /// Get or sets the entity type display name
        /// </summary>
        /// <value>
        /// The EntityTypeDisplayName
        /// </value>  
        public string EntityTypeDisplayName { get; set; }

        /// <summary>
        /// Get or sets the value
        /// </summary>
        /// <value>
        /// The Value
        /// </value>  
        public string Value { get; set; }

        /// <summary>
        /// Get or sets the IsList
        /// </summary>
        /// <value>
        /// The Email
        /// </value>  
        public bool IsList { get; set; }

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
