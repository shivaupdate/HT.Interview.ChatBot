using System;

namespace HT.Framework.Contracts
{
    /// <summary>
    /// ISerializer
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="objectToSerialize"></param>
        /// <returns></returns>
        string Serialize(object objectToSerialize);

        /// <summary>
        /// Deserialize <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectAsString"></param>
        /// <returns></returns>
        T Deserialize<T>(string objectAsString);

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="objectAsString"></param>
        /// <param name="objectType"></param>
        /// <returns></returns>
        object Deserialize(string objectAsString, Type objectType); 
    }
}
