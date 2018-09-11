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
            builder.RegisterType<AccessMatrixService>().As<IAccessMatrixService>();
            builder.RegisterType<AttachmentService>().As<IAttachmentService>();
            builder.RegisterType<CandidateService>().As<ICandidateService>();
            builder.RegisterType<CompetenceService>().As<ICompetenceService>();
            builder.RegisterType<CompetenceLevelService>().As<ICompetenceLevelService>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<GenderService>().As<IGenderService>();
            builder.RegisterType<IntentService>().As<IIntentService>(); 
            builder.RegisterType<InterviewService>().As<IInterviewService>(); 
            builder.RegisterType<InterviewTypeService>().As<IInterviewTypeService>();
            builder.RegisterType<InterviewTypeCompetenceMappingService>().As<IInterviewTypeCompetenceMappingService>();
            builder.RegisterType<MenuService>().As<IMenuService>();
            builder.RegisterType<RoleService>().As<IRoleService>(); 
            builder.RegisterType<IntentService>().As<IIntentService>();
            builder.RegisterType<InterviewService>().As<IInterviewService>();
            builder.RegisterType<ApiAiHttpClient>().As<IHttpClient>();
            builder.AddResourceService<Resources.Resources>(Common.Constants.ResourceComponent);
        }
    }
}
