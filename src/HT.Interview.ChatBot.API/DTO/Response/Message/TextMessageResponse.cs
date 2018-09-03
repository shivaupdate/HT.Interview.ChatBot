using HT.Interview.ChatBot.Common;

namespace HT.Interview.ChatBot.API.DTO.Response.Message
{
    /// <summary>
    /// TextMessageResponse
    /// </summary>
    public class TextMessageResponse : BaseMessageResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TextMessageResponse()
        {
            SetMessageType();
        }

        /// <summary>
        /// Agent's text reply. Line breaks are supported for Facebook Messenger, Kik, Slack, and Telegram one-click integrations.
        /// </summary>
        public string Speech { get; set; }

        /// <summary>
        /// Set message type
        /// </summary>
        public override void SetMessageType()
        {
            Type = Enums.Type.Text;
        }
    }
}
