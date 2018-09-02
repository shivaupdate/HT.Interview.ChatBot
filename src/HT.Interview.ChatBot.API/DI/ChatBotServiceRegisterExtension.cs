using Autofac;
using Microsoft.Extensions.Configuration;
using HT.Framework.Autofac;
using HT.Framework.ContentService.Resource.Autofac;
using HT.Framework.Contracts; 
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Data;
using HT.Interview.ChatBot.Services;

namespace HT.Interview.ChatBot.API.DI
{
    /// <summary>
    /// ChatBot data service registration
    /// </summary>
    public static class ChatBotServiceRegisterExtension
    {
        /// <summary>
        /// Add ChatBot data service
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configuration"></param>
        public static void AddChatBotDataService(this ContainerBuilder builder, IConfigurationRoot configuration)
        {
            builder.RegisterType<AutofacDependencyResolver>().As<IDependencyResolver>().SingleInstance();
            builder.RegisterType<ChatBotDataContext>().As<IChatBotDataContext>().
                WithParameter(new NamedParameter("connectionString", configuration["ConnectionStrings:ChatBotConnectionString"])).InstancePerLifetimeScope();

            builder.RegisterType<ChatBotDataFactory>().As<IChatBotDataFactory>().SingleInstance();
            
            builder.RegisterType<UserService>().As<IUserService>(); 

            //builder.AddResourceService<Resources.Resources>(Common.Constants.ResourceComponent);
        }
    }
}
