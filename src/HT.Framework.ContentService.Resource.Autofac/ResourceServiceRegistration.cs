using Autofac;
using HT.Framework.Contracts;

namespace HT.Framework.ContentService.Resource.Autofac
{
    public static class ResourceServiceRegistration
    {
        public static void AddResourceService<T>(this ContainerBuilder builder, string resource)
        {
            builder.RegisterType<ResourceService<T>>().Named<IContentService>(resource);
        }
    }
}
