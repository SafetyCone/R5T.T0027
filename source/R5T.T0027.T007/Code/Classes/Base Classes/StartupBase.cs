using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Dacia;

using R5T.T0027.A004;


namespace R5T.T0027.T007
{
    public abstract class StartupBase : T002.LoggedStartupBase
    {
        public StartupBase(ILogger logger)
            : base(logger)
        {
        }

        public override async Task ConfigureServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider)
        {
            await base.ConfigureServices(services, configurationAction, startupServicesProvider);

            var requiredServices = await this.GetRequiredServices(services, configurationAction, startupServicesProvider);

            var a004Services = services.AddA004Services(
                configurationAction,
                requiredServices.OrganizationProviderAction);

            var providedServices = new ProvidedServices()
                .FillFrom(requiredServices)
                .FillFrom(a004Services)
                ;

            await this.ConfigureServicesWithProvidedServices(services, configurationAction, startupServicesProvider,
                providedServices);
        }

        protected abstract Task<IRequiredServices> GetRequiredServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider);

        protected abstract Task ConfigureServicesWithProvidedServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider,
            IProvidedServices providedServices);
    }
}
