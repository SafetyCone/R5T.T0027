using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;
using R5T.Ostrogothia;
using R5T.Suebia.Standard;

using R5T.D0065.Standard;
using R5T.D0070.Standard;


namespace R5T.T0027.A001
{
    public static class IServiceCollectionExtensions
    {
        public static BasicServicesAggregation01 AddBasicServices(this IServiceCollection services,
            IServiceAction<IOrganizationProvider> organizationProviderAction)
        {
            // Level 0.
            var pathRelatedOperatorsAction = services.AddPathRelatedOperatorsAction();

            // Level 1.
            var executableDirectoryPathProviderAction = services.AddExecutableDirectoryPathProviderAction(
                pathRelatedOperatorsAction.StringlyTypedPathOperatorAction);
            var secretsDirectoryFilePathProviderAction = services.AddSecretsDirectoryFilePathProviderAction(
                organizationProviderAction,
                pathRelatedOperatorsAction.StringlyTypedPathOperatorAction);

            // Level 2.
            var sppSettingsFilePathProviderAction = services.AddDefaultJsonAppSettingsFilePathProviderAction(
                executableDirectoryPathProviderAction.ExecutableDirectoryPathProviderAction,
                pathRelatedOperatorsAction.FileNameOperatorAction,
                pathRelatedOperatorsAction.StringlyTypedPathOperatorAction);

            return new BasicServicesAggregation01
            {
                AppSettingsFilePathServices = sppSettingsFilePathProviderAction,
                ExecutableDirectoryPathServices = executableDirectoryPathProviderAction,
                PathRelatedOperators = pathRelatedOperatorsAction,
                SecretsDirectoryFilePathServices = secretsDirectoryFilePathProviderAction,
            };
        }
    }
}
