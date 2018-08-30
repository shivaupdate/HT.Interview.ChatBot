using System.Globalization;
using System.Reflection;
using System.Resources;
using HT.Framework.Contracts;

namespace HT.Framework.ContentService.Resource
{
    public class ResourceService<T> : IContentService<T>
    {
        public string GetString(string key, CultureInfo culture = null)
        {
            if (culture == null) culture = CultureInfo.CurrentUICulture;
            PropertyInfo property = typeof(T).GetProperty("ResourceManager");
            if (property == null) return key;
            ResourceManager rm = property.GetValue(null, null) as ResourceManager;
            if (rm != null) return rm.GetString(key, culture);
            return key;
        }

        public string this[string key] => GetString(key);
    }
}
