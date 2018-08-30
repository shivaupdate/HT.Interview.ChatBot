using System.Globalization;

namespace HT.Framework.Contracts
{
    /// <summary>
    /// Provides the interface for various content services used by the application (e.g. getting label text from a CMS/resource assembly)
    /// </summary>
    public interface IContentService
    {
        /// <summary>
        /// Get the equivalent string for a given key
        /// </summary>
        /// <param name="key">Key used to identify the string</param>
        /// <param name="culture"></param>
        /// <returns>String value if found, otherwise null</returns>
        string GetString(string key, CultureInfo culture = null);

        string this[string key] { get; }
    }

    public interface IContentService<T> : IContentService
    {
    }
}
