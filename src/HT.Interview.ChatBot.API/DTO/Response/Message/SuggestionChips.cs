using HT.Interview.ChatBot.Common;

namespace HT.Interview.ChatBot.API.DTO.Response.Message
{
    /// <summary>
    /// SuggestionChips
    /// </summary>
    public class SuggestionChips : BaseMessageResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SuggestionChips()
        {
            SetMessageType();
        }

        /// <summary>
        /// Suggestions
        /// </summary>
        public SuggestionsTitles[] Suggestions { get; set; }

        /// <summary>
        /// Set message type
        /// </summary>
        public override void SetMessageType()
        {
            Type = Enums.Type.Simple_Response;
        }
    }

    /// <summary>
    ///  SuggestionsTitles
    /// </summary>
    public class SuggestionsTitles
    {
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; } 
    }
}
