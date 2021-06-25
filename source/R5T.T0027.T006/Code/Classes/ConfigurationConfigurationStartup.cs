using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Dacia;

using R5T.T0027.Configuration.DefaultAppSettings;
using R5T.T0027.Configuration.T001;

using R5T.T0027.A002;


namespace R5T.T0027.T006
{
    public class ConfigurationConfigurationStartup : T002.LoggedStartupBase
    {
        public ConfigurationConfigurationStartup(ILogger<ConfigurationConfigurationStartup> logger)
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
            ;
        }

        public override async Task ConfigureServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider)
        {
            await base.ConfigureServices(services, configurationAction, startupServicesProvider);

            // Level 1.
            var appSettingsServices = services.AddAppSettingsServices(configurationAction);

            // Operations.
            var addAddDefaultAndEnvironmentNameSpecificAppSettingsFilePathsAction = services.AddAddDefaultAndEnvironmentNameSpecificAppSettingsFilePathsAction(
                appSettingsServices.DefaultAppSettingsFilePathServices.AppSettingsFilePathProvider,
                appSettingsServices.EnvironmentNameSpecificAppSettingsFilePathServices.EnvironmentNameSpecificAppSettingsFilePathProviderAction);

            services
                .Run(addAddDefaultAndEnvironmentNameSpecificAppSettingsFilePathsAction)
                ;

            var addDefaultAndEnvironmentNameSpecificAppSettingsFilePathsServices = new AddDefaultAndEnvironmentNameSpecificAppSettingsFilePathsAggregation01
            {
                AddDefaultAndEnvironmentNameSpecificAppSettingsFilePathsAction = addAddDefaultAndEnvironmentNameSpecificAppSettingsFilePathsAction,
                AppSettingsServices = appSettingsServices,
            };

            await this.ConfigureServicesWithAppSettings(services, configurationAction, startupServicesProvider,
                addDefaultAndEnvironmentNameSpecificAppSettingsFilePathsServices);
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        protected virtual Task ConfigureServicesWithAppSettings(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider,
            AddDefaultAndEnvironmentNameSpecificAppSettingsFilePathsAggregation01 addDefaultAndEnvironmentNameSpecificAppSettingsFilePathsServices)
        {
            // Do nothing.

            return Task.CompletedTask;
        }
    }
}
