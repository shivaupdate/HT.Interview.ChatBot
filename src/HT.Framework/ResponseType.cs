namespace HT.Framework
{
        public enum ResponseType
        {
            //Indicates a general success
            Ok = 200,
            //Indicates a resource was created
            Created = 201,
            //Indicates that the request to the methods was invalid.
            //This could be inputs being null or ones that fail validation rules
            InvalidRequest = 400,
            //Indicates that the requested resource was not found
            ResourceNotFound = 404,
            //Indicates that the requested resource has changed or is already present
            Conflict = 409,
            //Indicates a general server side error
            GenericError = 500,


        }
    
}
