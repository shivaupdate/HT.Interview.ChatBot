namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// MetadataResponse
    /// </summary>
    public class MetadataResponse
    {
        #region Public Properties

        /// <summary>
        /// ID of the intent that produced this result.
        /// </summary>
        public string IntentId { get; set; }

        /// <summary>
        /// Indicates wheather webhook functionaly is enabled in the triggered intent.
        /// </summary>
        public bool WebhookUsed { get; set; }

        /// <summary>
        /// Indicates wheather to end coversation
        /// </summary>
        public bool EndConversation { get; set; }

        /// <summary>
        /// Indicates wheather is fallback intent
        /// </summary>
        public bool IsFallbackIntent { get; set; }

        /// <summary>
        /// Name of the intent that produced this result.
        /// </summary>
        public string IntentName { get; set; } 

        #endregion
    }
}
