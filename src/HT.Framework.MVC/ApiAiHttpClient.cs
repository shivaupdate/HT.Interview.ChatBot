using HT.Framework.Contracts;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HT.Framework.MVC
{
    /// <summary>
    /// ApiAiHttpClient
    /// </summary>
    public class ApiAiHttpClient : IHttpClient
    {
        /// <summary>
        /// HttpClient
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiAiSettings"></param> 
        public ApiAiHttpClient(ApiAiSettings apiAiSettings)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiAiSettings.AccessToken}");
            _httpClient.Timeout = apiAiSettings.Timeout;
            _httpClient.BaseAddress = new Uri($"{apiAiSettings.DefaultBaseUrl + apiAiSettings.DefaultApiVersion}");
        }

        /// <summary>
        /// Get async
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string query)
        { 
            _httpClient.BaseAddress = new Uri(_httpClient.BaseAddress.ToString() + query);
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(_httpClient.BaseAddress); 
            string content = await httpResponseMessage.Content.ReadAsStringAsync(); 
            return ApiAiJson<T>.Deserialize(content);
        }

        /// <summary>
        /// Post async
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            Task<HttpResponseMessage> httpResponseMessage = _httpClient.PostAsync(requestUri, content);

            if (httpResponseMessage == null)
            {
                throw new Exception("Post async error - Http response message is null.");
            }

            return httpResponseMessage;
        }

        /// <summary>
        /// Put async
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
        {
            Task<HttpResponseMessage> httpResponseMessage = _httpClient.PutAsync(requestUri.AbsoluteUri, content);

            if (httpResponseMessage == null)
            {
                throw new Exception("Put async error - Http response message is null.");
            }

            return httpResponseMessage;
        }

        /// <summary>
        /// Delete async
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
        {
            Task<HttpResponseMessage> httpResponseMessage = _httpClient.DeleteAsync(requestUri);

            if (httpResponseMessage == null)
            {
                throw new Exception("Delete async error - Http response message is null.");
            }

            return httpResponseMessage;
        }

    }
}
