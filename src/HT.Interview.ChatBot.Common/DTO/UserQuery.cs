using static HT.Interview.ChatBot.Common.Enums;

namespace HT.Interview.ChatBot.Common.DTO
{
    /// <summary>
    /// User Query
    /// </summary>
    public class UserQuery
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserQuery()
        {
            GetManageableOnly = false;
            RecordType = RecordType.All;
            SortExpression = nameof(UserName);
        }

        /// <summary>
        /// Get or Sets the Logged In User Id
        /// </summary>
        /// <value>
        /// The Logged In User Id
        /// </value>  
        public string LoggedInUserId { get; set; }

        /// <summary>
        /// Get or Set the Get Manageable Only
        /// </summary>
        /// <value>
        /// The Get Manageable Only
        /// </value> 
        public bool GetManageableOnly { get; set; }
         
        /// <summary>
        /// Get or Sets User Name
        /// </summary>
        /// <value>
        /// The User Name
        /// </value>  
        public string UserName { get; set; }

        /// <summary>
        /// Get or Sets User Id
        /// </summary>
        /// <value>
        /// The User Id
        /// </value>  
        public string UserId { get; set; }
         
        /// <summary>
        /// Get or Sets Record Type
        /// </summary>
        /// <value>
        /// The Record Type
        /// </value> 
        public RecordType RecordType { get; set; }

        /// <summary>
        /// Get or Sets Sort Expression
        /// </summary>
        /// <value>
        /// The Sort Expression
        /// </value> 
        public string SortExpression { get; set; }

    }
}
