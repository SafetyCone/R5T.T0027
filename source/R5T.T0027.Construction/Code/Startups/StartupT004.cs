using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Dacia;
using R5T.Ostrogothia;
using R5T.Ostrogothia.Rivet;

using R5T.T0027.A001;


namespace R5T.T0027.Construction
{
    public class StartupT004 : T004.StartupBase
    {
        public StartupT004(ILogger<StartupT004> logger)
            : base(logger)
        {
        }

        protected override Task ConfigureConfiguration_Internal(IConfigurationBuilder configurationBuilder, IServiceProvider startupServicesProvider)
        {
            // Do nothing.

            return Task.CompletedTask;
        }

        protected override Task ConfigureServicesWithProvidedServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider,
            IServicesAggregation01 basicServicesAggregation)
        {
            // Operations.
            var exerciseBasicServicesAction = services.AddExerciseBasicServicesAction(
                basicServicesAggregation.AppSettingsFilePathProvider,
                basicServicesAggregation.ExecutableDirectoryPathProviderAction,
                basicServicesAggregation.SecretsDirectoryPathProviderAction);

            services
                .Run(exerciseBasicServicesAction)
                ;

            return Task.CompletedTask;
        }

        protected override Task<IServiceAction<IOrganizationProvider>> GetOrganizationProviderAction(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider)
        {
            var organizationProviderAction = services.AddOrganizationProviderAction();

            return Task.FromResult(organizationProviderAction);
        }
    }
}
