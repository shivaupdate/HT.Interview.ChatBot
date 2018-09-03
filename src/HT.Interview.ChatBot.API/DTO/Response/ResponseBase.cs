using System;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// ResponseBase
    /// </summary>
    public class ResponseBase
    {
        #region Public Properties

        /// <summary>
        /// Unique identifier of the result.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Date and time of the request in UTC timezone using ISO-8601 format.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Contains data on how the request succeeded or failed.
        /// </summary>
        public StatusResponse Status { get; set; }

        /// <summary>
        /// Session id informed on request.
        /// </summary>
        public string SessionId { get; set; }

        #endregion
    }
}
