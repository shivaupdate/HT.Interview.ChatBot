using HT.Interview.ChatBot.Common;
using static HT.Interview.ChatBot.Common.Enums;

namespace HT.Interview.ChatBot.API.DTO
{
    /// <summary>
    /// User Claim Query
    /// </summary>
    public class UserQuery
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserQuery()
        {
            //GetManageableOnly = false;
            //RecordType = RecordType.All;
            //SortExpression = nameof(UserName);
            //CurrentPage = Constants.DefaultPage;
            //PageSize = Constants.NoLimit;
        }

        ///// <summary>
        ///// Get or Set the Get Manageable Only
        ///// </summary>
        ///// <value>
        ///// The Get Manageable Only
        ///// </value> 
        //public bool GetManageableOnly { get; set; }
         
        /// <summary>
        /// Get or Sets User Name
        /// </summary>
        /// <value>
        /// The User Name
        /// </value>  
        public string UserName { get; set; }

        ///// <summary>
        ///// Get or Sets User Id
        ///// </summary>
        ///// <value>
        ///// The User Id
        ///// </value>  
        //public string UserId { get; set; }
         
        ///// <summary>
        ///// Get or Sets Record Type
        ///// </summary>
        ///// <value>
        ///// The Record Type
        ///// </value> 
        //public RecordType RecordType { get; set; }

        ///// <summary>
        ///// Get or Sets Fields
        ///// </summary>
        ///// <value>
        ///// The Fields
        ///// </value> 
        //public string Fields { get; set; }

        ///// <summary>
        ///// Get or Sets Sort Expression
        ///// </summary>
        ///// <value>
        ///// The Sort Expression
        ///// </value> 
        //public string SortExpression { get; set; }

        ///// <summary>
        ///// Get or Sets Current Page
        ///// </summary>
        ///// <value>
        ///// The Current Page
        ///// </value> 
        //public int CurrentPage { get; set; }

        ///// <summary>
        ///// Get or Sets Page Size
        ///// </summary>
        ///// <value>
        ///// The Page Size
        ///// </value> 
        //public int PageSize { get; set; }
    }
}
