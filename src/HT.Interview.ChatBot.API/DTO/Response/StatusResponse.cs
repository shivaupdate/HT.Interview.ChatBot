using Newtonsoft.Json;

namespace HT.Interview.ChatBot.API.DTO.Response
{
    /// <summary>
    /// StatusResponse
    /// </summary>
    public class StatusResponse
    {
        #region Public Properties

        /// <summary>
        /// HTTP status code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Text description of error, or "success" if no error.
        /// </summary>
        public string ErrorType { get; set; }

        /// <summary>
        /// D of the error. Optionally returned if the request failed.
        /// </summary>
        public string ErrorId { get; set; }

        /// <summary>
        /// Text details of the error. Only returned if the request failed.
        /// </summary>
        public string ErrorDetails { get; set; }

        /// <summary>
        /// Check Code http status is success (200).
        /// </summary>
        [JsonIgnore]
        public bool IsSuccessStatusCode
        {
            get
            {
                if (Code == 200) return true;
                {
                    return false;
                } 
            }
        }

        #endregion
    }
}
