using Graphql.Api.Core.Schemas;
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
using Graphql.Api.Core.Services;
using Graphql.Api.Core.Types;

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
            ConfigureAppServices(services);
            ConfigureSchema(services);
            ConfigureMvc(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            SeedDatabase(app.ApplicationServices.GetService<IDatabaseSeeder>());
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseStaticFiles();
            app.UseMvc();
        }

        private void ConfigureAppServices(IServiceCollection services)
        {
            services.AddSingleton<IDocumentWriter>(new DocumentWriter(true));
            services.AddSingleton<IDocumentExecuter,DocumentExecuter>();
            services.AddSingleton<IExerciseService,ExerciseService>();
            services.AddSingleton<ITrainingPlanService,TrainingPlanService>();
            services.AddSingleton<ITrainingPlanGraphQLService,TrainingPlanGraphQLService>();
            services.AddSingleton<IUserTrainingPlanService,UserTrainingPlanService>();
            services.AddSingleton<IGraphQLProcessor,GraphQLProcessor>();
            services.AddSingleton<IDatabase,Database>();
            services.AddSingleton<IDatabaseSeeder,DatabaseSeeder>();
        }

        private void ConfigureSchema(IServiceCollection services)
        {
            services.AddSingleton<TrainingPlanType>();
            services.AddSingleton<TrainingWeekType>();
            services.AddSingleton<TrainingDayType>();
            services.AddSingleton<TrainingSessionType>();
            services.AddSingleton<ExerciseType>();
            services.AddSingleton<ExerciseSetType>();
            services.AddSingleton<TrainingPlanQuery>();
            services.AddSingleton<TrainingPlanMutation>();
            services.AddSingleton<TrainingPlanSchema>(x => new TrainingPlanSchema(type => (GraphType) x.GetService(type)));
        }

        private void ConfigureMvc(IServiceCollection services)
        {
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

        private void SeedDatabase(IDatabaseSeeder databaseSeeder)
        {
            databaseSeeder.Seed();
        }
    }
}
