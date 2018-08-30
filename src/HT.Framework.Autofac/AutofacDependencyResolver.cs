using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using HT.Framework.Contracts;

namespace HT.Framework.Autofac
{
    public class AutofacDependencyResolver : IDependencyResolver
    {
        private readonly IContainer _container;

        public AutofacDependencyResolver(IContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public T Resolve<T>(string name)
        {
            return _container.ResolveNamed<T>(name);
        }

        public T Resolve<T>(IDictionary<string, object> args)
        {
            var parameters = args.Select(parameter => new NamedParameter(parameter.Key, parameter.Value))
                                .Cast<Parameter>();
            return _container.Resolve<T>(parameters);
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _container.Resolve<IEnumerable<T>>();
        }
    }
}