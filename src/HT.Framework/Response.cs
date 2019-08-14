using System;

namespace HT.Framework
{
    /// <summary>
    /// Response
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Is suceess
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Error
        /// </summary>
        public string Error { get; }

        /// <summary>
        /// Is failure
        /// </summary>
        public bool IsFailure => !IsSuccess;

        /// <summary>
        /// Get or sets the response type
        /// </summary>
        public ResponseType ResponseType { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="error"></param>
        /// <param name="responseType"></param>
        protected Response(bool isSuccess, string error, ResponseType responseType = ResponseType.Ok)
        {
            if (isSuccess && error != string.Empty)
            {
                throw new InvalidOperationException();
            }

            if (!isSuccess && error == string.Empty)
            {
                throw new InvalidOperationException();
            }

            IsSuccess = isSuccess;
            Error = error;
            ResponseType = responseType;
        }

        /// <summary>
        /// Fail response
        /// </summary>
        /// <param name="error"></param>
        /// <param name="responseType"></param>
        /// <returns></returns>
        public static Response Fail(string error, ResponseType responseType = ResponseType.GenericError)
        {
            if (IsSuccessResponseCode(responseType))
            {
                throw new InvalidOperationException("Can accept only failure response types");
            }
            return new Response(false, error, responseType);
        }

        /// <summary>
        /// Fail response <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="error"></param>
        /// <param name="responseType"></param>
        /// <returns></returns>
        public static Response<T> Fail<T>(string error, ResponseType responseType = ResponseType.GenericError)
        {
            if (IsSuccessResponseCode(responseType))
            {
                throw new InvalidOperationException("Can accept only failure response types");
            }

            return new Response<T>(false, error, responseType);
        }

        /// <summary>
        /// Ok response
        /// </summary>
        /// <param name="responseType"></param>
        /// <returns></returns>
        public static Response Ok(ResponseType responseType = ResponseType.Ok)
        {
            if (!IsSuccessResponseCode(responseType))
            {
                throw new InvalidOperationException("Can accept only success response types");
            }

            return new Response(true, string.Empty, responseType);
        }

        /// <summary>
        /// Ok response <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="responseType"></param>
        /// <returns></returns>
        public static Response<T> Ok<T>(T value, ResponseType responseType = ResponseType.Ok)
        {
            if (!IsSuccessResponseCode(responseType))
            {
                throw new InvalidOperationException("Can accept only success response types");
            }

            return new Response<T>(true, string.Empty, responseType, value);
        }

        /// <summary>
        /// Is success response code
        /// </summary>
        /// <param name="responseType"></param>
        /// <returns></returns>
        private static bool IsSuccessResponseCode(ResponseType responseType)
        {
            return (responseType == ResponseType.Ok || responseType == ResponseType.Created);
        }

    }

    /// <summary>
    /// Respose <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> : Response
    {
        private readonly T _value;

        /// <summary>
        /// Value
        /// </summary>
        public T Value
        {
            get
            {
                if (!IsSuccess)
                {
                    throw new InvalidOperationException();
                }

                return _value;
            }
        }

        /// <summary>
        /// Response
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="error"></param>
        /// <param name="responseType"></param>
        /// <param name="value"></param>
        protected internal Response(bool isSuccess, string error, ResponseType responseType, T value = default(T))
            : base(isSuccess, error, responseType)
        {
            _value = value;
        }

    }
}
