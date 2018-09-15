using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// Gender response
    /// </summary>
    public class GenderResponse
    {
        /// <summary>
        /// Get or sets the Id
        /// </summary>
        /// <value>
        /// The Id
        /// </value>  

        public int Id { get; set; }

        /// <summary>
        /// Get or sets the Name
        /// </summary>
        /// <value>
        /// The Name
        /// </value>  
        public string Name { get; set; }


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
