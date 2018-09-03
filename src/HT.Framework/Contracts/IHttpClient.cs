using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HT.Framework.Contracts
{
    /// <summary>
    /// IHttpClient
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>
        /// Get async
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string query);

        /// <summary>
        /// Post async
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content);

        /// <summary>
        /// Put async
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content);

        /// <summary>
        /// Delete async
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> DeleteAsync(Uri requestUri);
    }
}
