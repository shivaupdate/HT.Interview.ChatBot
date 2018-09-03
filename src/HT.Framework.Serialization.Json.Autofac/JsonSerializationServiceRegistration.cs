using Autofac;
using HT.Framework.Contracts;

namespace HT.Framework.Serialization.Json.Autofac
{
    public static class JsonSerializationServiceRegistration
    {
        public static void AddResourceService(this ContainerBuilder builder, string resource)
        {
            builder.RegisterType<JsonSerializer>().As<ISerializer>();
        }
    }
}