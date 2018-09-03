using Autofac;
using Autofac.Core;
using HT.Framework.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace HT.Framework.Autofac
{
    /// <summary>
    /// AutofacDependencyResolver
    /// </summary>
    public class AutofacDependencyResolver : IDependencyResolver
    {
        private readonly IContainer _container;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="container"></param>
        public AutofacDependencyResolver(IContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Resolve <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// Resolve by name <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T Resolve<T>(string name)
        {
            return _container.ResolveNamed<T>(name);
        }

        /// <summary>
        /// Resolve by parameter <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public T Resolve<T>(IDictionary<string, object> args)
        {
            IEnumerable<Parameter> parameters = args.Select(parameter => new NamedParameter(parameter.Key, parameter.Value))
                                .Cast<Parameter>();
            return _container.Resolve<T>(parameters);
        }

        /// <summary>
        /// Resolve all <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> ResolveAll<T>()
        {
            return _container.Resolve<IEnumerable<T>>();
        }
    }
}