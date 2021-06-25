using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Ostrogothia;
using R5T.Suebia.Standard;

using R5T.T0027.A003;


namespace R5T.T0027.A001
{
    public static class IServiceCollectionExtensions
    {
        public static ServicesAggregation01 AddA001Services(this IServiceCollection services,
            IServiceAction<IOrganizationProvider> organizationProviderAction)
        {
            var a003Services = services.AddA003Services();
            
            var secretsDirectoryFilePathProviderAction = services.AddSecretsDirectoryFilePathProviderServices(
                organizationProviderAction,
                a003Services.StringlyTypedPathOperatorAction);

            return new ServicesAggregation01()
                .FillFrom(a003Services)
                .FillFrom(secretsDirectoryFilePathProviderAction)
                ;
        }
    }
}
