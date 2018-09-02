using System.ComponentModel.DataAnnotations;

namespace HT.Interview.ChatBot.API.DTO
{
    /// <summary>
    /// User Response
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// Get or sets the user Id
        /// </summary>
        /// <value>
        /// The Id
        /// </value> 
        public int Id { get; set; }
         
        /// <summary>
        /// Get or sets user Name
        /// </summary>
        /// <value>
        /// The User Name
        /// </value>   
        public string UserName { get; set; }

        /// <summary>
        /// Get or sets user Id
        /// </summary>
        /// <value>
        /// The User Id
        /// </value>   
        public string UserId { get; set; }
         
        /// <summary>
        /// Get or sets is active 
        /// </summary>
        /// <value>
        /// The Is Active 
        /// </value>   
        public bool IsActive { get; set; }

        /// <summary>
        /// Get or sets does user has write access        
        /// </summary>
        /// <value>
        /// The Does User Has Write Access
        /// </value> 
        public bool DoesUserHasWriteAccess { get; set; } 
    }
}
