using HT.Interview.ChatBot.API.DTO.Request;
using System.Linq;

namespace HT.Interview.ChatBot.API
{
    /// <summary>
    /// QueryExtension
    /// </summary>
    public static class QueryExtension
    {
        /// <summary>
        /// To query string
        /// </summary>
        /// <param name="queryRequest"></param>
        /// <returns></returns>
        public static string ToQueryString(this QueryRequest queryRequest)
        {
            string result  = $"&query={queryRequest.Query.FirstOrDefault()}";

            //if (!string.IsNullOrEmpty(queryRequest.Timezone))
            //{
            //    result += $"&timezone={queryRequest.Timezone}";
            //}

            result += $"&lang={queryRequest.Language}";

            //if (queryRequest.Contexts != null && queryRequest.Contexts.Count() > 0)
            //{
            //    foreach (var context in queryRequest.Contexts)
            //    {
            //        result += $"&contexts={context.Name}";
            //    }
            //}

            //if (queryRequest.Location != null)
            //{
            //    if (!string.IsNullOrEmpty(queryRequest.Location.Latitude) && !string.IsNullOrEmpty(queryRequest.Location.Longitude))
            //    {
            //        result += $"&latitude={queryRequest.Location.Latitude}&longitude={queryRequest.Location.Longitude}";
            //    }
            //}

            if (!string.IsNullOrEmpty(queryRequest.SessionId))
            {
                result += $"&sessionId={queryRequest.SessionId}";
            }

            return result;
        } 
    }
}
