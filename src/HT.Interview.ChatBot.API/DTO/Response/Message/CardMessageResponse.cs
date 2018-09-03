using HT.Interview.ChatBot.Common;
using System;

namespace HT.Interview.ChatBot.API.DTO.Response.Message
{
    /// <summary>
    /// CardMessageResponse
    /// </summary>
    [Serializable]
    public class CardMessageResponse : BaseMessageResponse
    { 
        /// <summary>
        /// Constructor
        /// </summary>
        public CardMessageResponse()
        {
            SetMessageType();
        } 

        /// <summary>
        /// Card title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Card subtitle.
        /// </summary>
        public string Subtitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Array of objects corresponding to card buttons.
        /// </summary>
        public CardMessageResponseButton[] Buttons { get; set; }
         
        /// <summary>
        /// Set message type
        /// </summary>
        public override void SetMessageType()
        {
            this.Type = (int)Enums.Type.Card;
        }
         
    }

    /// <summary>
    ///  CardMessageResponseButton
    /// </summary>
    public class CardMessageResponseButton
    {
        /// <summary>
        /// Button text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// A text sent back to API.AI or a URL to open.
        /// </summary>
        public string Postback { get; set; }
    }

}
