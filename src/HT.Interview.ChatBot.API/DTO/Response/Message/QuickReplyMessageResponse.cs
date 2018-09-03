using HT.Interview.ChatBot.Common;
using System;

namespace HT.Interview.ChatBot.API.DTO.Response.Message
{
    /// <summary>
    /// QuickReplyMessageResponse
    /// </summary>
    [Serializable]
    public class QuickReplyMessageResponse : BaseMessageResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public QuickReplyMessageResponse()
        {
            SetMessageType();
        }

        /// <summary>
        /// Quick replies title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Array of strings corresponding to quick replies.
        /// </summary>
        public string[] Replies { get; set; }

        /// <summary>
        /// Set message type
        /// </summary>
        public override void SetMessageType()
        {
            Type = Enums.Type.QuickReply;
        }
    }
}
