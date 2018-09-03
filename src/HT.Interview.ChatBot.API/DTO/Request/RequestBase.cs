using Newtonsoft.Json;

namespace HT.Interview.ChatBot.API.DTO.Request
{
    /// <summary>
    /// RequestBase
    /// </summary>
    public class RequestBase
    {
        #region Private Fields

        private string _v;

        #endregion

        #region Public Properties

        /// <summary>
        /// Version of the protocol, e.g. v=20150910
        /// </summary>
        [JsonIgnore]
        public string V
        {
            get
            {
                if (string.IsNullOrEmpty(_v))
                {
                    _v = ApiAiVersion.Default;
                }

                return _v;
            }
            set
            {
                _v = value;
            }
        }
    }

    #endregion

}
