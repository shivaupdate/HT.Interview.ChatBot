namespace HT.Framework
{
    /// <summary>
    /// Response type
    /// </summary>
    public enum ResponseType
    {
        /// <summary>
        /// Indicates a general success
        /// </summary>
        Ok = 200,

        /// <summary>
        /// Indicates a resource was created
        /// </summary>
        Created = 201,

        /// <summary>
        /// Indicates that the request to the methods was invalid.
        /// This could be inputs being null or ones that fail validation rules
        /// </summary>
        InvalidRequest = 400,

        /// <summary>
        /// Indicates that the requested resource was not found
        /// </summary>
        ResourceNotFound = 404,

        /// <summary>
        /// Indicates that the requested resource has changed or is already present
        /// </summary>
        Conflict = 409,

        /// <summary>
        /// Indicates a general server side error
        /// </summary>
        GenericError = 500,
    }
}
