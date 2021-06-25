using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Dacia;
using R5T.Ostrogothia;

using R5T.T0027.A001;


namespace R5T.T0027.T004
{
    public abstract class StartupBase : T002.LoggingStartupBase
    {
        public StartupBase(ILogger logger)
            : base(logger)
        {
        }

        protected override async Task ConfigureServices_Internal(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider)
        {
            var organizationProviderAction = await this.GetOrganizationProviderAction(services, configurationAction, startupServicesProvider);

            var a001ServicesAggregation = services.AddA001Services(
                organizationProviderAction);

            await this.ConfigureServicesWithProvidedServices(services, configurationAction, startupServicesProvider,
                a001ServicesAggregation);
        }

        protected abstract Task<IServiceAction<IOrganizationProvider>> GetOrganizationProviderAction(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider);

        protected abstract Task ConfigureServicesWithProvidedServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider,
            IServicesAggregation01 a001ServicesAggregation);
    }
}
