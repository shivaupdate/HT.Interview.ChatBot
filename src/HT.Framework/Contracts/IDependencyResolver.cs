using System.Collections.Generic;

namespace HT.Framework.Contracts
{
    public interface IDependencyResolver
    {
        /// <summary>
        /// Resolve the default dependency
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>();
        /// <summary>
        /// Resolves the named dependency
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        T Resolve<T>(string name);
        /// <summary>
        /// Resolves the specified args.
        /// </summary>
        /// <typeparam name="T" />
        /// <param name="args">The args.</param>
        /// <returns>
        ///  0.
        /// </returns>
        T Resolve<T>(IDictionary<string, object> args);
        /// <summary>
        /// Resolves all.
        /// </summary>
        /// <typeparam name="T" />
        /// <returns>
        /// IEnumerable{``0}.
        /// </returns>
        IEnumerable<T> ResolveAll<T>();
    }
}
