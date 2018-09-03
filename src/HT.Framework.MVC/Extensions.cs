using System;
using AutoMapper; 

namespace HT.Framework.MVC
{
    /// <summary>
    /// BaseEntityExtensions
    /// </summary>
    public static class BaseEntityExtensions
    {
        /// <summary>
        /// Get mapped response
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="response"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public static TTarget GetMappedResponse<TSource, TTarget>(this Response<TSource> response, IMapper mapper)
        {
            EnforceFailures(response);
            if (response.IsSuccess)
            {
                var val = response.Value;
                TTarget mappedResponse = mapper.Map<TTarget>(val);
                return mappedResponse;
            }
            return default(TTarget);
        }

        /// <summary>
        /// Enforce Failures
        /// </summary>
        /// <param name="response"></param>
        public static void EnforceFailures( this Response response)
        {
            if(response.IsSuccess) return;
            switch (response.ResponseType)
            { 
                case ResponseType.InvalidRequest:
                    throw new InvalidOperationException(response.Error);
                default:
                    throw new Exception();
            }
        }
    }
}