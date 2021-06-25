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
            //return gettingApplicationSpecification.UseSingleStageStartupWithServiceDependencies<StartupT004>();
            //return gettingApplicationSpecification.UseStartupWithConfigurationAndServiceDependencies<StartupT004>();
            //return gettingApplicationSpecification.UseStartupWithLoggingServiceDependency<T006.ConfigurationConfigurationStartup>();
            //return gettingApplicationSpecification.UseStartupWithLoggingServiceDependency<StartupT006>();
            //return gettingApplicationSpecification.UseStartupWithConfigurationAndServiceDependencies<ZeroServiceDependenciesStartup>();
            return gettingApplicationSpecification.UseStartupWithLoggingServiceDependency<StartupT007>();
        }

        public static Task<IApplicationSpecification> SelectConfigurationStartup(this Task<IApplicationSpecification> gettingApplicationSpecification)
        {
            //return gettingApplicationSpecification.UseStartupWithConfigurationConfigurationAndServiceDependencies<StartupT004>();
            return gettingApplicationSpecification.UseStartupWithConfigurationConfigurationAndServiceDependencies<ConfigurationStartupTestStartup>();
        }

        public static Task<IApplicationSpecification> SelectConfigurationConfigurationStartup(this Task<IApplicationSpecification> gettingApplicationSpecification)
        {
            //return gettingApplicationSpecification.UseStartupWithLoggingServiceDependency<StartupT004>();
            return gettingApplicationSpecification.UseStartupWithLoggingServiceDependency<T006.ConfigurationConfigurationStartup>();
        }

        #region Hidden

        public static Task<IApplicationSpecification> UseStartupWithConfigurationAndServiceDependencies<TStartup>(this Task<IApplicationSpecification> gettingApplicationSpecification)
            where TStartup : class, IStartup
        {
            return gettingApplicationSpecification.UseStartup<TStartup>(() =>
            {
                return ApplicationBuilder.Instance
                    .NewApplication()
                    .SelectConfigurationStartup()
                    .BuildServiceProvider();
            },
            startupProviderServiceProviderServices =>
            {
                startupProviderServiceProviderServices.AddDefaultLogging();

                return Task.CompletedTask;
            });
        }

        public static Task<IApplicationSpecification> UseStartupWithConfigurationConfigurationAndServiceDependencies<TStartup>(this Task<IApplicationSpecification> gettingApplicationSpecification)
            where TStartup : class, IStartup
        {
            return gettingApplicationSpecification.UseStartup<TStartup>(() =>
            {
                return ApplicationBuilder.Instance
                    .NewApplication()
                    .SelectConfigurationConfigurationStartup()
                    .BuildServiceProvider();
            },
            startupProviderServiceProviderServices =>
            {
                startupProviderServiceProviderServices.AddDefaultLogging();

                return Task.CompletedTask;
            });
        }

        public static Task<ServiceProvider> UseSecondOfThreeStageStartup()
        {
            return ApplicationBuilder.Instance
                .NewApplication()
                .SelectConfigurationStartup()
                .BuildServiceProvider();
        }

        public static Task<ServiceProvider> UseThirdOfThreeStageStartup<TConfigurationStartup>()
            where TConfigurationStartup : class, IStartup
        {
            return ApplicationBuilder.Instance
                .NewApplication()
                .SelectConfigurationConfigurationStartup()
                .BuildServiceProvider();
        }

        public static Task<IApplicationSpecification> UseThreeStageStartupWithThirdStageServiceDepdendencies<TStartup, TConfigurationStartup, TConfigurationConfigurationStartup>(
            this Task<IApplicationSpecification> gettingApplicationSpecification)
            where TStartup : class, IStartup
            where TConfigurationStartup : class, IStartup
            where TConfigurationConfigurationStartup: class, IStartup
        {
            return gettingApplicationSpecification.UseStartup<TStartup>(() =>
            {
                return ApplicationBuilder.Instance
                    .NewApplication()
                    .UseStartup<TConfigurationStartup>(() =>
                    {
                        return ApplicationBuilder.Instance
                            .NewApplication()
                            .UseStartup<TConfigurationConfigurationStartup>(startupDependencyServices =>
                            {
                                startupDependencyServices.AddDefaultLogging();

                                return Task.CompletedTask;
                            })
                            .BuildServiceProvider();
                    })
                    .BuildServiceProvider();
            });
        }

        public static Task<IApplicationSpecification> UseTwoStageStartupWithSecondStageServiceDepdendencies<TStartup, TConfigurationStartup>(
            this Task<IApplicationSpecification> gettingApplicationSpecification)
            where TStartup : class, IStartup
            where TConfigurationStartup : class, IStartup
        {
            return gettingApplicationSpecification.UseStartup<TStartup>(() =>
            {
                return ApplicationBuilder.Instance
                    .NewApplication()
                    .UseStartup<TConfigurationStartup>(startupDependencyServices =>
                    {
                        startupDependencyServices.AddDefaultLogging();

                        return Task.CompletedTask;
                    })
                    .BuildServiceProvider();
            });
        }

        public static Task<IApplicationSpecification> UseStartupWithLoggingServiceDependency<TStartup>(this Task<IApplicationSpecification> gettingApplicationSpecification)
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

        #endregion
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
            // This does not actually work since it does not have any access to all the diff services.

            //var getConfigurationAction = services.AddGetConfigurationAction(
            //    configurationAction);

            //services
                //.Run(getConfigurationAction)
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
            //await this.ServiceProvider.Run<ExerciseBasicServices>();
            //await this.ServiceProvider.Run<ExerciseAppSettingsServices>();
            await this.ServiceProvider.Run<ExerciseMachineLocationAwareSecretsDirectory>();
        }

        private Task HelloWorld()
        {
            Console.WriteLine("Hello world!");

            return Task.CompletedTask;
        }
    }
}
