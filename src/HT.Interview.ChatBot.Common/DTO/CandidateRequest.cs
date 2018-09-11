using HT.Interview.ChatBot.Common;
using System;
using static HT.Interview.ChatBot.Common.Enums;

namespace HT.Interview.ChatBot.Common.DTO
{
    /// <summary>
    /// CandidateRequest
    /// </summary>
    public class CandidateRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CandidateRequest()
        { 
         
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
        /// Get or sets first name
        /// </summary>
        /// <value>
        /// The FirstName
        /// </value>  
        /// <summary>
        /// Get or sets the first name
        /// </summary>
        /// <value>
        /// The FirstName
        /// </value> 

        public string FirstName { get; set; }

        /// <summary>
        /// Get or sets the LastName
        /// </summary>
        /// <value>
        /// The LastName
        /// </value> 


        public string LastName { get; set; }

        /// <summary>
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 


        public string Email { get; set; }

        /// <summary>
        /// Get or sets the GenderId
        /// </summary>
        /// <value>
        /// The GenderId
        /// </value> 


        public int GenderId { get; set; }

        /// <summary>
        /// Get or sets the Mobile
        /// </summary>
        /// <value>
        /// The Mobile
        /// </value> 


        public string Mobile { get; set; }

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
