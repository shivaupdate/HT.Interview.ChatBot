using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper; 
using HT.Interview.ChatBot.API.DI;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;

namespace HT.Interview.ChatBot.API
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {    
            //Adding AutoMapper Support 
            services.AddAutoMapper();
            services.AddMvc(config =>
                {
                    // Add XML Content Negotiation
                    config.RespectBrowserAcceptHeader = true;
                    config.InputFormatters.Add(new XmlSerializerInputFormatter(config));
                    config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy("InterviewChatBot",
                    policy => policy.WithOrigins("http://localhost:4200")
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());
            });

            services.AddLogging();
            //Adding Swagger
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Hexaware Interview ChatBot API",
                    Description = "A REST API that exposes Hexaware's Interview ChatBot Data API",
                    TermsOfService = "None"
                });
                options.MapType<IEnumerable<string>>(() => new Schema { Type = "string[]", Format = "string[]" });
            });
        
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddApplicationInsightsTelemetry(new ApplicationInsightsServiceOptions
            {
                EnableAdaptiveSampling = true
            });

            services.Configure<MvcOptions>(options => options.Filters.Add(new ProducesAttribute("application/json")));
            IContainer container = null;
            services.Add(new ServiceDescriptor(typeof(IContainer), provider => container, ServiceLifetime.Singleton));
            ContainerBuilder builder = new ContainerBuilder();
            builder.AddChatBotDataService(Configuration);
            builder.Populate(services);
            container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
             app.UseCors("InterviewChatBot");
            app.UseSwagger();
            app.UseSwaggerUI(ui =>
            {
                ui.SwaggerEndpoint("/swagger/v1/swagger.json", "ChatBot API V1");
            });
            app.UseMvc();
        }
    }
}
