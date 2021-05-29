using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using R5T.Dacia;
using R5T.Plymouth;
using R5T.Plymouth.ProgramAsAService;
using R5T.Plymouth.Startup;

using R5T.T0027.T001;
using R5T.T0027.T002;

using R5T.T0027.Construction.Operations;


namespace R5T.T0027.Construction
{
    static class IApplicationSpecificationExtensions
    {
        public static Task<IApplicationSpecification> SelectStartup(this Task<IApplicationSpecification> gettingApplicationSpecification)
        {
            //return gettingApplicationSpecification.UseSingleStageStartup<ZeroServiceDependenciesStartup>();
            //return gettingApplicationSpecification.UseSingleStageStartupWithServiceDependencies<LoggingStartup>();
            //return gettingApplicationSpecification.UseSingleStageStartup<T003.Startup>();
            return gettingApplicationSpecification.UseSingleStageStartupWithServiceDependencies<StartupT004>();
        }

        public static Task<IApplicationSpecification> UseSingleStageStartupWithServiceDependencies<TStartup>(this Task<IApplicationSpecification> gettingApplicationSpecification)
            where TStartup : class, IStartup
        {
            return gettingApplicationSpecification.UseStartup<TStartup>(startupDependencyServices =>
            {
                startupDependencyServices.AddDefaultLogging();

                return Task.CompletedTask;
            });
        }

        /// <summary>
        /// Use a simple, single-stage startup.
        /// </summary>
        public static Task<IApplicationSpecification> UseSingleStageStartup<TStartup>(this Task<IApplicationSpecification> gettingApplicationSpecification)
            where TStartup : class, IStartup
        {
            return gettingApplicationSpecification.UseStartup<TStartup>();
        }
    }


    class Program : ProgramAsAServiceBase
    {
        #region Main

        static Task Main()
        {
            return ApplicationBuilder.Instance
                .NewApplication()
                .SelectStartup()
                .UseProgramAsAService<Program>()
                .AddConfigureServicesAction(Program.ConfigureServicesAction)
                .BuildProgramAsAServiceHost()
                .Run();
        }

        #endregion

        static Task ConfigureServicesAction(IServiceCollection services, IServiceAction<IConfiguration> configurationAction)
        {
            var getConfigurationAction = services.AddGetConfigurationAction(
                configurationAction);

            services
                .Run(getConfigurationAction)
                ;

            return Task.CompletedTask;
        }


        private IServiceProvider ServiceProvider { get; }


        public Program(IApplicationLifetime applicationLifetime,
            IServiceProvider serviceProvider)
            : base(applicationLifetime)
        {
            this.ServiceProvider = serviceProvider;
        }

        protected override async Task ServiceMain(CancellationToken stoppingToken)
        {
            //await this.HelloWorld();
            //await this.ServiceProvider.Run<GetConfiguration>();
            await this.ServiceProvider.Run<ExerciseBasicServices>();
        }

        private Task HelloWorld()
        {
            Console.WriteLine("Hello world!");

            return Task.CompletedTask;
        }
    }
}
