using System;

namespace HT.Framework
{
    public class Response
    {
        public bool IsSuccess { get; }
        public string Error { get; }
        public bool IsFailure => !IsSuccess;
        public ResponseType ResponseType { get; set; }

        protected Response(bool isSuccess, string error, ResponseType responseType = ResponseType.Ok)
        {
            if (isSuccess && error != string.Empty)
                throw new InvalidOperationException();
            if (!isSuccess && error == string.Empty)
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            Error = error;
            ResponseType = responseType;
        }
        public static Response Fail(string error,ResponseType responseType = ResponseType.GenericError)
        {
            if(IsSuccessResponseCode(responseType))
                throw new InvalidOperationException("Can accept only failure response types");
            return new Response(false, error, responseType);
        }

        public static Response<T> Fail<T>(string error,ResponseType responseType = ResponseType.GenericError)
        {
            if (IsSuccessResponseCode(responseType))
                throw new InvalidOperationException("Can accept only failure response types");
            return new Response<T>(false, error, responseType);
        }

        public static Response Ok(ResponseType responseType = ResponseType.Ok)
        {
            if (!IsSuccessResponseCode(responseType))
                throw new InvalidOperationException("Can accept only success response types");
            return new Response(true, string.Empty,responseType);
        }

        public static Response<T> Ok<T>(T value, ResponseType responseType = ResponseType.Ok)
        {
            if (!IsSuccessResponseCode(responseType))
                throw new InvalidOperationException("Can accept only success response types");
            return new Response<T>(true, string.Empty, responseType, value);
        }

        private static bool IsSuccessResponseCode(ResponseType responseType)
        {
            return (responseType == ResponseType.Ok || responseType == ResponseType.Created);
        }
        
    }


    public class Response<T> : Response
    {
        private readonly T _value;

        public T Value
        {
            get
            {
                if (!IsSuccess)
                    throw new InvalidOperationException();

                return _value;
            }
        }

        protected internal Response(bool isSuccess, string error, ResponseType responseType, T value = default(T))
            : base(isSuccess, error,responseType)
        {
            _value = value;
        }

    }
}
