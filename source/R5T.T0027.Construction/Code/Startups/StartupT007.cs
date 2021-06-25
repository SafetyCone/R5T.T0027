using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Dacia;
using R5T.Ostrogothia.Rivet;

using R5T.T0027.T007;


namespace R5T.T0027.Construction
{
    public class StartupT007 : T007.StartupBase
    {
        public StartupT007(ILogger<StartupT007> logger)
            : base(logger)
        {
        }

        protected override Task ConfigureServicesWithProvidedServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider, IProvidedServices providedServices)
        {
            var exerciseMachineLocationAwareSecretsDirectoryAction = services.AddExerciseMachineLocationAwareSecretsDirectoryAction(
                providedServices.MachineLocationProviderAction,
                providedServices.OrganizationDataSecretsDirectoryPathProviderAction,
                providedServices.SecretsDirectoryFilePathProviderAction);

            services
                .Run(exerciseMachineLocationAwareSecretsDirectoryAction)
                ;

            return Task.CompletedTask;
        }

        protected override Task<IRequiredServices> GetRequiredServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider)
        {
            var organizationProviderAction = services.AddOrganizationProviderAction();

            var requiredServices = new RequiredServices
            {
                OrganizationProviderAction = organizationProviderAction,
            };

            return Task.FromResult(requiredServices as IRequiredServices);
        }
    }
}
