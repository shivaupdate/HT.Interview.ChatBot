using Autofac;
using HT.Framework.Contracts;

namespace HT.Framework.ContentService.Resource.Autofac
{
    /// <summary>
    /// ResourceServiceRegistration
    /// </summary>
    public static class ResourceServiceRegistration
    {
        /// <summary>
        /// Add resource service <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="resource"></param>
        public static void AddResourceService<T>(this ContainerBuilder builder, string resource)
        {
            builder.RegisterType<ResourceService<T>>().Named<IContentService>(resource);
        }
    }
}
