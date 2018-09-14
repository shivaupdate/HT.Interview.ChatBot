using HT.Framework.MVC;
using HT.Interview.ChatBot.API.DTO.Response.Message;
using HT.Interview.ChatBot.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace HT.Interview.ChatBot.API.DTO
{
    /// <summary>
    /// MessageCollectionConverter
    /// </summary>
    public class MessageCollectionConverter : JsonConverter
    {
        /// <summary>
        /// Can covert
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(BaseMessageResponse[]);
        }

        /// <summary>
        /// Read Json
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            BaseMessageResponse[] result = null;

            var jArray = JArray.Load(reader);

            if (jArray != null)
            {
                result = new BaseMessageResponse[jArray.Count];

                for (var i = 0; i < jArray.Count; i++)
                { 
                    var messageType =  EnumHelper.Parse<Enums.Type>(jArray[i]["type"].ToString());

                    switch (messageType)
                    {
                        case Enums.Type.Text:
                            result[i] = ApiAiJson<TextMessageResponse>.Deserialize(jArray[i].ToString());
                            break;

                        case Enums.Type.Card:
                            result[i] = ApiAiJson<CardMessageResponse>.Deserialize(jArray[i].ToString());
                            break;

                        case Enums.Type.QuickReply:
                            result[i] = ApiAiJson<QuickReplyMessageResponse>.Deserialize(jArray[i].ToString());
                            break;

                        case Enums.Type.Image:
                            result[i] = ApiAiJson<ImageMessageResponse>.Deserialize(jArray[i].ToString());
                            break;

                        case Enums.Type.Custom_Payload:
                            result[i] = ApiAiJson<PayloadMessageResponse>.Deserialize(jArray[i].ToString());
                            break;

                        case Enums.Type.Simple_Response:
                            result[i] = ApiAiJson<SimpleResponse>.Deserialize(jArray[i].ToString());
                            break;

                        case Enums.Type.Suggestion_Chips:
                            result[i] = ApiAiJson<SuggestionChips>.Deserialize(jArray[i].ToString());
                            break;

                        default:
                            result[i] = null;
                            break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Write Json
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, (BaseMessageResponse[])value);
        }
    }
}
