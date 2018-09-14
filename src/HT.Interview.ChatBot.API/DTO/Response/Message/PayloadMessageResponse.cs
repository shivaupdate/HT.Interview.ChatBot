using HT.Interview.ChatBot.Common;

namespace HT.Interview.ChatBot.API.DTO.Response.Message
{
    /// <summary>
    /// PayloadMessageResponse
    /// </summary>
    public class PayloadMessageResponse : BaseMessageResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PayloadMessageResponse()
        {
            SetMessageType();
        }

        /// <summary>
        /// Developer defined JSON. It is sent without modifications
        /// </summary>
        public object Payload { get; set; }

        /// <summary>
        /// Set message type
        /// </summary>
        public override void SetMessageType()
        {
            Type = Enums.Type.Custom_Payload;
        }
    }
}
