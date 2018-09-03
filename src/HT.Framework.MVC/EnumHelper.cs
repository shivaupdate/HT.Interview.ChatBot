using System;

namespace HT.Framework.MVC
{
    /// <summary>
    /// EnumHelper
    /// </summary>
    public class EnumHelper
    {
        /// <summary>
        /// Parse <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T Parse<T>(string input)
        {
            return (T)Enum.Parse(typeof(T), input, true);
        }
    }
}
