using System.Runtime.Serialization;

namespace HT.Framework.MVC
{
    /// <summary>
    /// EnumExtension
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Display name
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string DisplayName(this System.Enum source)
        {
            var fi = source.GetType().GetField(source.ToString());

            var attributes = (EnumMemberAttribute[])fi.GetCustomAttributes(typeof(EnumMemberAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Value;
            else return source.ToString();
        }
    }
}
