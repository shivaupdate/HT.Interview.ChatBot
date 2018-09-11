﻿using static HT.Interview.ChatBot.Common.Enums;

namespace HT.Interview.ChatBot.API.DTO.Request
{
    /// <summary>
    /// QueryRequest
    /// </summary>
    public class QueryRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public QueryRequest()
        {
            Language = Language.English;
        }

        /// <summary>
        /// Candidate Id
        /// </summary>
        public int CandidateId { get; set; }

        /// <summary>
        /// Dialogflow generated intent id
        /// </summary>
        public string DialogflowGeneratedIntentId { get; set; }

        /// <summary>
        /// Time taken
        /// </summary>
        public int? TimeTaken { get; set; }

        /// <summary>
        /// The natural language text to be processed. The request can have multiple query parameters. 
        /// </summary>
        public string[] Query { get; set; }

        /// <summary>
        /// The confidence of the corresponding query parameter having been correctly recognized by a 
        /// speech recognition system. 0 represents no confidence and 1 represents the highest confidence. 
        /// </summary>
        public float[] Confidence { get; set; }

        /// <summary>
        /// A string token up to 36 symbols long, used to identify the client and to manage sessions parameters (including contexts) per client.
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// Array of additional input context objects.
        /// </summary>
        public Context[] Contexts { get; set; }

        /// <summary>
        /// If true, all current contexts in a session will be reset before the new ones are set. False by default.
        /// </summary>
        public bool ResetContexts { get; set; }

        /// <summary>
        /// Array of entities that replace developer defined entities for this request only. The entity(ies) need to exist in the developer console
        /// </summary>
        public Entity[] Entities { get; set; }

        /// <summary>
        /// Time zone from IANA Time Zone Database. 
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// Latitude and longitude values.
        /// </summary>
        public LocationRequest Location { get; set; }

        /// <summary>
        /// Full request coming from the integrated platform (Facebook Messenger, Slack, etc.) 
        /// </summary>
        public OriginalRequest OriginalRequest { get; set; }
    }
}
