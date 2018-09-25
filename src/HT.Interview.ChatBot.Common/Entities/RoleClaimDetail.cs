using System.ComponentModel.DataAnnotations;

namespace HT.Interview.ChatBot.Common.Entities
{
    public class RoleClaimDetail
    {
        /// <summary>
        /// Get or sets the id
        /// </summary>
        /// <value>
        /// The Id
        /// </value>  
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Get or sets the role id
        /// </summary>
        /// <value>
        /// The RoleId
        /// </value>  
        [Required]
        public int RoleId { get; set; }

        /// <summary>
        /// Get or sets the role name
        /// </summary>
        /// <value>
        /// The RoleName
        /// </value>  
        [Required]
        public string RoleName { get; set; }

        /// <summary>
        /// Get or sets the claim id
        /// </summary>
        /// <value>
        /// The ClaimId
        /// </value>  
        [Required]
        public int ClaimId { get; set; }

        /// <summary>
        /// Get or sets the claim name
        /// </summary>
        /// <value>
        /// The ClaimName
        /// </value>  
        [Required]
        public string ClaimName { get; set; }

        /// <summary>
        /// Get or sets the value
        /// </summary>
        /// <value>
        /// The Value
        /// </value>  
        [Required]
        public string Value { get; set; }

        /// <summary>
        /// Get or sets the is active
        /// </summary>
        /// <value>
        /// The IsActive
        /// </value>  
        [Required]
        public bool IsActive { get; set; }
    }
}
