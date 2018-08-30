using AutoMapper;
using System;

namespace HT.Framework.MVC
{
    public static class BaseEntityExtensions
    {
        public static TTarget GetMappedResponse<TSource, TTarget>(this Response<TSource> response)
        {
            EnforceFailures(response);
            if (response.IsSuccess)
            {
                TSource val = response.Value;
                TTarget mappedResponse = Mapper.Map<TTarget>(val);
                return mappedResponse;
            }
            return default(TTarget);
        }


        public static void EnforceFailures(this Response response)
        {
            if (response.IsSuccess)
            {
                return;
            }

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