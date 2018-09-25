using HT.Interview.ChatBot.Common;
using HT.Interview.ChatBot.Common.Entities;
using System;
using System.Collections.Generic;
using static HT.Interview.ChatBot.Common.Enums;

namespace HT.Interview.ChatBot.API.DTO.Request
{
    /// <summary>
    /// IntentRequest
    /// </summary>
    public class IntentRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public IntentRequest()
        { 
            RecordType = RecordType.All;
            SortExpression = nameof(DisplayName);
            CurrentPage = Constants.DefaultPage;
            PageSize = Constants.PageSizeTen;
        }

        /// <summary>
        /// Get or sets the logged in user id
        /// </summary>
        /// <value>
        /// The LoggedInUserId
        /// </value>  
        public string LoggedInUserId { get; set; }

        /// <summary>
        /// Get or sets id
        /// </summary>
        /// <value>
        /// The Id
        /// </value>  
        public int Id { get; set; }

        /// <summary>
        /// Get or sets the display name
        /// </summary>
        /// <value>
        /// The DisplayName
        /// </value> 
        
        public string DisplayName { get; set; }

        /// <summary>
        /// Get or sets the text
        /// </summary>
        /// <value>
        /// The Text
        /// </value> 
        
        public string Text { get; set; }
         
        /// <summary>
        /// Get or sets the intent training phrase
        /// </summary>
        /// <value>
        /// The IntentTrainingPhrase
        /// </value> 
        public ICollection<IntentTrainingPhrase> IntentTrainingPhrase { get; set; }

        /// <summary>
        /// Get or sets the intent parameter
        /// </summary>
        /// <value>
        /// The IntentParameter
        /// </value> 
        public ICollection<IntentParameter> IntentParameter { get; set; }

        /// <summary>
        /// Get or sets the intent suggestion
        /// </summary>
        /// <value>
        /// The IntentSuggestion
        /// </value> 
        public ICollection<IntentSuggestion> IntentSuggestion { get; set; }

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

        /// <summary>
        /// Get or sets record type
        /// </summary>
        /// <value>
        /// The RecordType
        /// </value> 
        public RecordType RecordType { get; set; }

        /// <summary>
        /// Get or sets fields
        /// </summary>
        /// <value>
        /// The Fields
        /// </value> 
        public string Fields { get; set; }

        /// <summary>
        /// Get or Sets sort expression
        /// </summary>
        /// <value>
        /// The Sort Expression
        /// </value> 
        public string SortExpression { get; set; }

        /// <summary>
        /// Get or sets current page
        /// </summary>
        /// <value>
        /// The Current Page
        /// </value> 
        public int CurrentPage { get; set; }

        /// <summary>
        /// Get or sets page size
        /// </summary>
        /// <value>
        /// The Page Size
        /// </value> 
        public int PageSize { get; set; }
    }
}
