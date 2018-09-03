using HT.Interview.ChatBot.API.DTO.Response.Message;
using Newtonsoft.Json;
using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// FulfillmentResponse
    /// </summary>
    [Serializable]
    public class FulfillmentResponse
    {
        #region Public Properties

        /// <summary>
        /// ext to be pronounced to the user / shown on the screen
        /// </summary>
        public string Speech { get; set; }

        /// <summary>
        /// Array of message objects
        /// </summary>       
        [JsonConverter(typeof(MessageCollectionConverter))]
        public BaseMessageResponse[] Messages { get; set; }
        
        #endregion

    }
}
