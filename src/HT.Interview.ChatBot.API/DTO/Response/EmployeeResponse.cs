using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// Employee response
    /// </summary>
    public class EmployeeResponse
    {
        /// <summary>
        /// Get or sets the Id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 
        public int Id { get; set; }
        /// <summary>
        /// Get or sets the EmployeeNo
        /// </summary>
        /// <value>
        /// The EmployeeNo
        /// </value> 

        public int EmployeeNo { get; set; }
        /// <summary>
        /// Get or sets the UserName
        /// </summary>
        /// <value>
        /// The UserName
        /// </value> 
        public string UserName { get; set; }
        /// <summary>
        /// Get or sets the RoleId
        /// </summary>
        /// <value>
        /// The RoleId
        /// </value> 
        public int RoleId { get; set; }

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
