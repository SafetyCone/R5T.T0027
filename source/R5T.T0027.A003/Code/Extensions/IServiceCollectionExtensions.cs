using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Lombardy;

using R5T.D0063;
using R5T.D0063.Default;
using R5T.D0065.Standard;
using R5T.D0070;
using R5T.D0070.Default;


namespace R5T.T0027.A003
{
    public static class IServiceCollectionExtensions
    {
        public static ServicesAggregation01 AddA003Services(this IServiceCollection services)
        {
            // Level 0.
            var environmentVariableProviderServices = services.AddEnvironmentVariableProviders();
            var pathRelatedOperatorsServices = services.AddPathRelatedOperatorsAction();

            // Level 1.
            var executableDirectoryPathProviderServices = services.AddExecutableDirectoryPathProviderAction(
                pathRelatedOperatorsServices.StringlyTypedPathOperatorAction);

            // Level 2.
            var defaultAppSettingsFilePathProviderServices = services.AddDefaultJsonAppSettingsFilePathProviderAction(
                executableDirectoryPathProviderServices.ExecutableDirectoryPathProviderAction,
                pathRelatedOperatorsServices.FileNameOperatorAction,
                pathRelatedOperatorsServices.StringlyTypedPathOperatorAction);

            return new ServicesAggregation01()
                .FillFrom(defaultAppSettingsFilePathProviderServices)
                .FillFrom(environmentVariableProviderServices)
                .FillFrom(executableDirectoryPathProviderServices)
                .FillFrom(pathRelatedOperatorsServices)
                ;
        }
    }
}
