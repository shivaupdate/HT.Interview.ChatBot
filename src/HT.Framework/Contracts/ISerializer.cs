using System;

namespace HT.Framework.Contracts
{
    public interface ISerializer
    {
        string Serialize(object objectToSerialize);

        T Deserialize<T>(string objectAsString);

        object Deserialize(string objectAsString, Type objectType);
        //dynamic Deserialize(string objectAsString);
    }
}
