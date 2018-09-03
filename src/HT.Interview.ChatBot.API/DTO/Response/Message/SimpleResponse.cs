using HT.Interview.ChatBot.Common;

namespace HT.Interview.ChatBot.API.DTO.Response.Message
{
    /// <summary>
    /// SimpleResponse
    /// </summary>
    public class SimpleResponse : BaseMessageResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SimpleResponse()
        {
            SetMessageType();
        }

        /// <summary>
        /// Agent's simple response
        /// </summary>
        public string TextToSpeech { get; set; }

        /// <summary>
        /// Set message type
        /// </summary>
        public override void SetMessageType()
        {
            Type = Enums.Type.Simple_Response;
        }
    }
}
