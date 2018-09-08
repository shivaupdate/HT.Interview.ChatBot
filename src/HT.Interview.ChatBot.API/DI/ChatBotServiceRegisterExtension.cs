using Autofac; 
using HT.Framework.Contracts;
using HT.Framework.DI;
using HT.Framework.MVC;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Data;
using HT.Interview.ChatBot.Services;
using Microsoft.Extensions.Configuration;

namespace HT.Interview.ChatBot.API.DI
{
    /// <summary>
    /// ChatBotServiceRegisterExtension
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
            builder.RegisterInstance(new ApiAiSettings(configuration)); 
            builder.RegisterType<DependencyResolver>().As<IDependencyResolver>();
            builder.RegisterType<ChatBotDataContext>().As<IChatBotDataContext>().
                WithParameter(new NamedParameter("connectionString", configuration["ConnectionStrings:ChatBotConnectionString"]));

            builder.RegisterType<ChatBotDataFactory>().As<IChatBotDataFactory>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<DialogflowService>().As<IDialogflowService>();
            builder.RegisterType<ApiAiHttpClient>().As<IHttpClient>();
            builder.AddResourceService<Resources.Resources>(Common.Constants.ResourceComponent);
        }
    }
}
