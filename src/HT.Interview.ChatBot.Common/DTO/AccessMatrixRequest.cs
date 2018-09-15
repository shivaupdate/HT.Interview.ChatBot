﻿using HT.Interview.ChatBot.Common;
using System;
using static HT.Interview.ChatBot.Common.Enums;

namespace HT.Interview.ChatBot.Common.DTO
{
    /// <summary>
    /// AccessMatrixRequestAccessMatrixRequest
    /// </summary>
    public class AccessMatrixRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AccessMatrixRequest()
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
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 
        
        public int Id { get; set; }

        /// <summary>
        /// Get or sets the roleId
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 



        
        public int RoleId { get; set; }

        /// <summary>
        /// Get or sets the menuId
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 

        
        public int MenuId { get; set; }

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
