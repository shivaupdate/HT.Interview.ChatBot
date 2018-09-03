using System.Collections.Generic;

namespace HT.Interview.ChatBot.API.DTO
{
    /// <summary>
    /// Context
    /// </summary>
    public class Context
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Parameters
        /// </summary>
        public Dictionary<string, object> Parameters { get; set; }

        /// <summary>
        /// Lifespan
        /// </summary>
        public int? Lifespan { get; set; }
    }
}
