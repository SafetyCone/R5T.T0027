using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;

using R5T.D0062;
using R5T.D0062.Chamavia;
using R5T.D0065.Standard;
using R5T.D0070;


namespace R5T.T0027.A002
{
    public static class IServiceCollectionExtensions
    {
        public static AppSettingsServicesAggregation01 AddAppSettingsServices(this IServiceCollection services,
            IServiceAction<IConfiguration> configurationAction)
        {
            // Level 0.
            var defaultEnvironmentNameProviderAction = services.AddDevelopmentDefaultEnvironmentNameProviderAction();
            var pathRelatedOperatorsAction = services.AddPathRelatedOperatorsAction();

            // Level 1.
            var environmentNameProviderServices = services.AddEnvironmentNameProviderAction(
                configurationAction,
                defaultEnvironmentNameProviderAction);
            var executableDirectoryPathProviderAction = services.AddExecutableDirectoryPathProviderAction(
                pathRelatedOperatorsAction.StringlyTypedPathOperatorAction);

            // Level 2.
            var defaultAppSettingsFilePathProviderAction = services.AddDefaultJsonAppSettingsFilePathProviderAction(
                executableDirectoryPathProviderAction.ExecutableDirectoryPathProviderAction,
                pathRelatedOperatorsAction.FileNameOperatorAction,
                pathRelatedOperatorsAction.StringlyTypedPathOperatorAction);
            var environmentSpecificAppSettingsFilePathProviderAction = services.AddEnvironmentNameSpecificAppSettingsFilePathProviderAction(
                defaultAppSettingsFilePathProviderAction.AppSettingsDirectoryPathProviderAction,
                environmentNameProviderServices.EnvironmentNameProviderAction,
                pathRelatedOperatorsAction.FileNameOperatorAction,
                pathRelatedOperatorsAction.StringlyTypedPathOperatorAction);

            return new AppSettingsServicesAggregation01
            {
                DefaultAppSettingsFilePathServices = defaultAppSettingsFilePathProviderAction,
                DefaultEnvironmentNameProvider = defaultEnvironmentNameProviderAction,
                EnvironmentNameProviderServices = environmentNameProviderServices,
                EnvironmentNameSpecificAppSettingsFilePathServices = environmentSpecificAppSettingsFilePathProviderAction,
                ExecutableDirectoryPathServices = executableDirectoryPathProviderAction,
                PathRelatedOperatorServices = pathRelatedOperatorsAction,
            };
        }
    }
}
