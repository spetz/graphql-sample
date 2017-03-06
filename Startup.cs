using Graphql.Api.Core.Schemas;
using Graphql.Api.Core.Types;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Source.Core.Repositories;
using Source.Core.Services;

namespace Graphql.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<StarWarsQuery>();
            services.AddSingleton<StarWarsMutation>();
            services.AddScoped<HumanType>();
            services.AddScoped<DroidType>();
            services.AddScoped<CharacterInterface>();
            services.AddSingleton<StarWarsSchema>();
            services.AddSingleton<StarWarsRepository>();
            services.AddSingleton<IDocumentWriter>(new DocumentWriter(true));
            services.AddSingleton<IDocumentExecuter,DocumentExecuter>();
            services.AddSingleton<StarWarsSchema>(x => new StarWarsSchema(type => (GraphType) x.GetService(type)));
            services.AddSingleton<ITrainingPlanService,TrainingPlanService>();
            services.AddMvc()
                    .AddJsonOptions(x => 
                    {
                        x.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        x.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ";
                        x.SerializerSettings.Formatting = Formatting.Indented;
                        x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        x.SerializerSettings.Converters.Add(new StringEnumConverter
                        {
                            AllowIntegerValues = true,
                            CamelCaseText = true
                        });
                    });;;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
