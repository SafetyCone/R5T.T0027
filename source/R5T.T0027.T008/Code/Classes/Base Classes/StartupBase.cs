using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Dacia;

using R5T.T0027.Configuration.DefaultAppSettings;

using R5T.T0027.A001;


namespace R5T.T0027.T008
{
    public abstract class StartupBase : T002.LoggedStartupBase
    {
        public StartupBase(ILogger logger)
            : base(logger)
        {
        }

        public override async Task ConfigureConfiguration(IConfigurationBuilder configurationBuilder, IServiceProvider startupServicesProvider)
        {
            await base.ConfigureConfiguration(configurationBuilder, startupServicesProvider);

            this.Logger.Log(
                () => configurationBuilder.AddDefaultJsonAppSettingsFile(),
                "Adding default appsettings.json file to configuration configuation startup IConfiguration...",
                "Added default appsettings.json file to configuration configuation startup IConfiguration.");
        }

        public override async Task ConfigureServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider)
        {
            await base.ConfigureServices(services, configurationAction, startupServicesProvider);

            var loggerAction = ServiceAction.New<ILogger>(() =>
            {
                services.AddLogging(loggingBuilder =>
                {
                    this.ConfigureLogging(services, configurationAction, startupServicesProvider, loggingBuilder).Wait(); // Bad, sync-over-async, but don't want to rework service action to be async yet!
                });
            });

            var requiredServices = await this.GetRequiredServices(services, configurationAction, startupServicesProvider);

            var a001Services = services.AddA001Services(
                requiredServices.OrganizationProviderAction);

            var providedServices = new ProvidedServices()
                .FillFrom(a001Services)
                .FillFrom(requiredServices)
                ;

            await this.ConfigureServicesWithProvidedServices(services, configurationAction, startupServicesProvider,
                providedServices);
        }

        /// <summary>
        /// Base method adds a console logger and sets the minimum log level to <see cref="LogLevelHelper.DefaultLogLevel"/> .
        /// </summary>
        protected virtual Task ConfigureLogging(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider,
            ILoggingBuilder loggingBuilder)
        {
            loggingBuilder.AddDefaultLogging();

            return Task.CompletedTask;
        }

        protected abstract Task<IRequiredServices> GetRequiredServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider);

        protected abstract Task ConfigureServicesWithProvidedServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider,
            IProvidedServices providedServices);
    }
}

