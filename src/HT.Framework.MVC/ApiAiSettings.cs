using Microsoft.Extensions.Configuration;
using System;

namespace HT.Framework.MVC
{
    /// <summary>
    /// ApiAiSettings
    /// </summary>
    public class ApiAiSettings
    {
        /// <summary>
        /// Access token
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// Default api version
        /// </summary>
        public string DefaultApiVersion { get; }

        /// <summary>
        /// Default base url
        /// </summary>
        public string DefaultBaseUrl { get; }

        /// <summary>
        /// Default language
        /// </summary>
        public string DefaultLanguage { get; }

        /// <summary>
        /// Timeout
        /// </summary>
        public TimeSpan Timeout  { get; } 

        /// <summary>
        /// Constructor
        /// </summary>
        public ApiAiSettings(IConfigurationRoot configuration)
        {
            AccessToken = configuration["ApiAi:AccessToken"];
            DefaultApiVersion = configuration["ApiAi:DefaultApiVersion"];
            DefaultBaseUrl = configuration["ApiAi:DefaultBaseUrl"];
            DefaultLanguage = configuration["ApiAi:DefaultLanguage"];
            Timeout = TimeSpan.FromSeconds(60);
        }

    }
}
