using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Dacia;

using R5T.T0027.T006;


namespace R5T.T0027.Construction
{
    public class StartupT006 : T006.ConfigurationConfigurationStartup
    {
        public StartupT006(ILogger<StartupT006> logger)
            : base(logger)
        {
        }

        protected override async Task ConfigureServicesWithAppSettings(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider,
            AddDefaultAndEnvironmentNameSpecificAppSettingsFilePathsAggregation01 addDefaultAndEnvironmentNameSpecificAppSettingsFilePathsServices)
        {
            await base.ConfigureServicesWithAppSettings(services, configurationAction, startupServicesProvider, addDefaultAndEnvironmentNameSpecificAppSettingsFilePathsServices);

            // Operations.
            var appSettingsServices = addDefaultAndEnvironmentNameSpecificAppSettingsFilePathsServices.AppSettingsServices;

            var exerciseAppSettingsServicesAction = services.AddExerciseAppSettingsServicesAction(
                appSettingsServices.DefaultAppSettingsFilePathServices.AppSettingsFilePathProvider,
                appSettingsServices.EnvironmentNameSpecificAppSettingsFilePathServices.EnvironmentNameSpecificAppSettingsFilePathProviderAction);

            services
                .Run(exerciseAppSettingsServicesAction)
                ;
        }
    }
}
