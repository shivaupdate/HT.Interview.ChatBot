using static HT.Interview.ChatBot.Common.Enums;

namespace HT.Interview.ChatBot.Common.DTO
{
    /// <summary>
    /// UserRequest
    /// </summary>
    public class UserRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserRequest()
        { 
            RecordType = RecordType.All; 
        }

        /// <summary>
        /// Get or Sets the Logged In User Id
        /// </summary>
        /// <value>
        /// The LoggedInUserId
        /// </value>  
        public string LoggedInUserId { get; set; }

        /// <summary>
        /// Get or sets user id
        /// </summary>
        /// <value>
        /// The Id
        /// </value>  
        public int  Id { get; set; }

        /// <summary>
        /// Get or sets first name
        /// </summary>
        /// <value>
        /// The FirstName
        /// </value>  
        public string FirstName { get; set; }

        /// <summary>
        /// Get or sets first name
        /// </summary>
        /// <value>
        /// The LastName
        /// </value>  
        public string LastName { get; set; }

        /// <summary>
        /// Get or sets Email
        /// </summary>
        /// <value>
        /// The Email
        /// </value>  
        public string Email { get; set; }

        /// <summary>
        /// Get or sets record type
        /// </summary>
        /// <value>
        /// The RecordType
        /// </value> 
        public RecordType RecordType { get; set; } 
    }
}
