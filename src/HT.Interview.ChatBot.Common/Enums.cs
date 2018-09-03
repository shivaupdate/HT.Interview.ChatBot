using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace HT.Interview.ChatBot.Common
{
    /// <summary>
    /// Enums
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// Record type
        /// </summary>
        public enum RecordType
        {
            /// <summary>
            /// In Active
            /// </summary>
            InActive = 0,

            /// <summary>
            /// Active
            /// </summary>
            Active = 1,

            /// <summary>
            /// All
            /// </summary>
            All = 2
        }

        /// <summary>
        /// Request type
        /// </summary>
        public enum RequestType
        {
            /// <summary>
            /// Query
            /// </summary>
            Query = 0,

            /// <summary>
            /// Tts
            /// </summary>
            Tts = 1,

            /// <summary>
            /// Entities
            /// </summary>
            Entities = 2,

            /// <summary>
            /// User entities
            /// </summary>
            UserEntities = 3,

            /// <summary>
            /// Intents
            /// </summary>
            Intents = 4
        }

        /// <summary>
        /// Type
        /// </summary> 
        public enum Type
        {
            /// <summary>
            /// Text
            /// </summary> 
            Text,

            /// <summary>
            /// Card
            /// </summary> 
            Card ,

            /// <summary>
            /// Quick reply
            /// </summary> 
            QuickReply ,

            /// <summary>
            /// Image
            /// </summary> 
            Image,

            /// <summary>
            /// Payload
            /// </summary> 
            Payload,

            /// <summary>
            /// Simple response
            /// </summary> 
            Simple_Response ,

            /// <summary>
            /// Suggestion chips
            /// </summary>
            Suggestion_Chips
        }

        /// <summary>
        /// Source
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Source
        {
            /// <summary>
            /// Facebook
            /// </summary>
            [EnumMember(Value = "facebook")]
            Facebook = 0,

            /// <summary>
            /// Kik
            /// </summary>
            [EnumMember(Value = "kik")]
            Kik = 1,

            /// <summary>
            /// Slack
            /// </summary>
            [EnumMember(Value = "slack")]
            Slack = 2,

            /// <summary>
            /// Slack test bot
            /// </summary>
            [EnumMember(Value = "slack_testbot")]
            SlackTestbot = 3,

            /// <summary>
            /// Line
            /// </summary>
            [EnumMember(Value = "line")]
            Line = 4,

            /// <summary>
            /// Skype
            /// </summary>
            [EnumMember(Value = "skype")]
            Skype = 5,

            /// <summary>
            /// Spark
            /// </summary>
            [EnumMember(Value = "spark")]
            Spark = 6,

            /// <summary>
            /// Telegram
            /// </summary>
            [EnumMember(Value = "telegram")]
            Telegram = 7,

            /// <summary>
            /// Tropo
            /// </summary>
            [EnumMember(Value = "tropo")]
            Tropo = 8,

            /// <summary>
            /// Twilio
            /// </summary>
            [EnumMember(Value = "twilio")]
            Twilio = 9,

            /// <summary>
            /// TwiloIp
            /// </summary>
            [EnumMember(Value = "twilio-ip")]
            TwilioIp = 10,

            /// <summary>
            /// Twitter
            /// </summary>
            [EnumMember(Value = "twitter")]
            Twitter = 11
        }

        /// <summary>
        /// Language
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Language
        {
            /// <summary>
            /// English
            /// </summary>
            [EnumMember(Value = "en")]
            English = 0,

            /// <summary>
            /// Brazilian Portuguese
            /// </summary>
            [EnumMember(Value = "pt-br")]
            BrazilianPortuguese = 1,

            /// <summary>
            /// Chinese Cantonese
            /// </summary>
            [EnumMember(Value = "zh-hk")]
            ChineseCantonese = 2,

            /// <summary>
            /// Chinese Simplified
            /// </summary>
            [EnumMember(Value = "zh-cn")]
            ChineseSimplified = 3,

            /// <summary>
            /// Chinese Traditional
            /// </summary>
            [EnumMember(Value = "zh-tw")]
            ChineseTraditional = 4,

            /// <summary>
            /// Dutch
            /// </summary>
            [EnumMember(Value = "nl")]
            Dutch = 5,

            /// <summary>
            /// French
            /// </summary>
            [EnumMember(Value = "fr")]
            French = 6,

            /// <summary>
            /// German
            /// </summary>
            [EnumMember(Value = "de")]
            German = 7,

            /// <summary>
            /// Italian
            /// </summary>
            [EnumMember(Value = "it")]
            Italian = 8,

            /// <summary>
            /// Japanese
            /// </summary>
            [EnumMember(Value = "ja")]
            Japanese = 9,

            /// <summary>
            /// Korean
            /// </summary>
            [EnumMember(Value = "ko")]
            Korean = 10,

            /// <summary>
            /// Portuguese
            /// </summary>
            [EnumMember(Value = "pt")]
            Portuguese = 11,

            /// <summary>
            /// Russian
            /// </summary>
            [EnumMember(Value = "ru")]
            Russian = 12,

            /// <summary>
            /// Spanish
            /// </summary>
            [EnumMember(Value = "es")]
            Spanish = 13,

            /// <summary>
            /// Ukrainian
            /// </summary>
            [EnumMember(Value = "uk")]
            Ukrainian = 14
        }
    }
}
