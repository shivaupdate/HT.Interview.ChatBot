using HT.Framework.Contracts;
using System;
using System.IO;

namespace HT.Framework.Serialization.Json
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize(object objectToSerialize)
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

            using (var output = new StringWriter())
            {
                serializer.Serialize(output, objectToSerialize);
                return output.ToString();
            }
        }

        public T Deserialize<T>(string objectAsString)
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            T result;

            using (var input = new StringReader(objectAsString))
            {
                Newtonsoft.Json.JsonTextReader reader = new Newtonsoft.Json.JsonTextReader(input);
                result = serializer.Deserialize<T>(reader);
            }
            return result;
        }

        public object Deserialize(string objectAsString, Type objectType)
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            dynamic result;

            using (var input = new StringReader(objectAsString))
            {
                result = serializer.Deserialize(input, objectType);
            }
            return Convert.ChangeType(result, objectType);
        }
    }
}
