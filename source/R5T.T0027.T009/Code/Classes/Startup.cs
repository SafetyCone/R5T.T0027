using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Dacia;
using R5T.Ostrogothia.Rivet;

using R5T.T0027.Configuration.SecretsFilePaths;
using R5T.T0027.T008;


namespace R5T.T0027.T009
{
    public class Startup : StartupBase
    {
        public Startup(ILogger<Startup> logger)
            : base(logger)
        {
        }

        /// <summary>
        /// <para>Base implementation adds:</para>
        /// <para>• <see cref="AddSecretsJsonFilePath"/> operation.</para>
        /// </summary>
        protected override Task ConfigureServicesWithProvidedServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider,
            IProvidedServices providedServices)
        {
            // Operations.
            var addSecretsJsonFilePathAction = services.AddAddSecretsJsonFilePathAction(
                providedServices.SecretsDirectoryFilePathProviderAction);

            services
                .Run(addSecretsJsonFilePathAction)
                ;

            return Task.CompletedTask;
        }

        protected override Task<IRequiredServices> GetRequiredServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider)
        {
            var organizationProviderAction = services.AddOrganizationProviderAction_Old();

            var requiredServices = new RequiredServices
            {
                OrganizationProviderAction = organizationProviderAction,
            };

            return Task.FromResult(requiredServices as IRequiredServices);
        }
    }
}
