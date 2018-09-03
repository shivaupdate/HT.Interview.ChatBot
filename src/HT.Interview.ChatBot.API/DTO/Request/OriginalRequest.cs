using static HT.Interview.ChatBot.Common.Enums;

namespace HT.Interview.ChatBot.API.DTO.Request
{
    /// <summary>
    /// OriginalRequest
    /// </summary>
    public class OriginalRequest
    {
        /// <summary>
        /// Request source name. 
        /// Possible values: "facebook", "kik", "slack", "slack_testbot", "line", 
        /// "skype", "spark", "telegram", "tropo", "twilio", "twilio-ip", "twitter"
        /// </summary>
        public Source Source { get; set; }

        /// <summary>
        /// Request data.
        /// </summary>
        public object Data { get; set; }
    }
}
