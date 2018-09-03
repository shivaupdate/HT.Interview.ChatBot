using HT.Interview.ChatBot.Common;
using System;

namespace HT.Interview.ChatBot.API.DTO.Response.Message
{
    /// <summary>
    /// ImageMessageResponse
    /// </summary>
    [Serializable]
    public class ImageMessageResponse : BaseMessageResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ImageMessageResponse()
        {
            SetMessageType();
        }

        /// <summary>
        /// Public URL to the image file.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Set meesage type
        /// </summary>
        public override void SetMessageType()
        {
            this.Type = (int)Enums.Type.Image;
        }
    }
}
