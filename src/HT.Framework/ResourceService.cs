using HT.Framework.Contracts;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace HT.Framework
{
    /// <summary>
    /// Resource service <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResourceService<T> : IContentService<T>
    {
        /// <summary>
        /// Get string
        /// </summary>
        /// <param name="key"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public string GetString(string key, CultureInfo culture = null)
        {
            if (culture == null) culture = CultureInfo.CurrentUICulture;
            PropertyInfo property = typeof(T).GetProperty("ResourceManager");
            if (property == null) return key;
            ResourceManager rm = property.GetValue(null, null) as ResourceManager;
            if (rm != null) return rm.GetString(key, culture);
            return key;
        }

        /// <summary>
        /// Get string
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key] => GetString(key);
    }
}
