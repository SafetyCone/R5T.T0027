using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Magyar.Extensions;
using R5T.Ostrogothia;
using R5T.Suebia.Default;
using R5T.Suebia.D0073;
using R5T.Suebia.Standard;

using R5T.D0073.Standard;

using R5T.T0027.A003;


namespace R5T.T0027.A004
{
    public static class IServiceCollectionExtensions
    {
        public static ServicesAggregation01 AddA004Services(this IServiceCollection services,
            IServiceAction<IConfiguration> configurationAction,
            IServiceAction<IOrganizationProvider> organizationProviderAction)
        {
            var a003Services = services.AddA003Services();

            var organizationDataSecretsDirectoryFilePathProviderAction = services.AddSecretsDirectoryPathProviderActionAsOrganizationDataSecretsAction(
                organizationProviderAction,
                a003Services.StringlyTypedPathOperatorAction);

            var machineLocationProviderServices = services.AddMachineLocationProvider(
                configurationAction);

            var secretsDirectoryPathProviderAction = services.AddMachineLocationAwareSecretsDirectoryPathProviderAction(
                a003Services.ExecutableDirectoryPathProviderAction,
                machineLocationProviderServices.MachineLocationProviderAction,
                organizationDataSecretsDirectoryFilePathProviderAction.OrganizationDataSecretsDirectoryPathProviderAction);

            var secretsDirectoryFilePathProviderAction = services.AddSecretsDirectoryFilePathProviderAction_Old(
                secretsDirectoryPathProviderAction,
                a003Services.StringlyTypedPathOperatorAction);

            return new ServicesAggregation01()
                .FillFrom(a003Services)
                .FillFrom(organizationDataSecretsDirectoryFilePathProviderAction)
                .FillFrom(machineLocationProviderServices)
                .ModifyAs<ServicesAggregation01, IServicesAggregation01Increment>(aggregation =>
                {
                    aggregation.SecretsDirectoryFilePathProviderAction = secretsDirectoryFilePathProviderAction;
                    aggregation.SecretsDirectoryPathProviderAction = secretsDirectoryPathProviderAction;
                })
                ;
        }
    }
}
