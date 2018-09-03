using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HT.Interview.ChatBot.API.DTO.Response.Message
{
    /// <summary>
    /// BaseMessageResponse
    /// </summary>
    [JsonObject]
    public abstract class BaseMessageResponse
    {
        /// <summary>
        /// Type
        /// </summary>
        public int Type { get; set; }
        
        /// <summary>
        /// Set message type
        /// </summary>
        public abstract void SetMessageType();

        #region Private Methods

        /// <summary>
        /// On deserialized
        /// </summary>
        /// <param name="context"></param>
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            SetMessageType();
        }

        /// <summary>
        /// On serialized
        /// </summary>
        /// <param name="context"></param>
        [OnSerialized]
        private void OnSerialized(StreamingContext context)
        {
            SetMessageType();
        }

        #endregion        
    }
}
