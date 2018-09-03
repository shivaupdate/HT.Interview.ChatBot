using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace HT.Interview.ChatBot.API.DTO
{
    /// <summary>
    /// ApiAiJson <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiAiJson<T>
    { 
        /// <summary>
        /// Constructor
        /// </summary>
        static ApiAiJson()
        {
            _settings.Converters.Add(new StringEnumConverter());
        }
         
        /// <summary>
        /// Serialize <typeparamref name="T"/>
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string Serialize(T t)
        {
            return JsonConvert.SerializeObject(t, _settings);
        }

        /// <summary>
        /// Deserialize <typeparamref name="T"/>
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _settings);
        }

        /// <summary>
        /// Settigns
        /// </summary>
        private static JsonSerializerSettings _settings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented

        }; 
    }
}
