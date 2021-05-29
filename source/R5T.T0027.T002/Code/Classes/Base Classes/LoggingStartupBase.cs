using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Dacia;


namespace R5T.T0027.T002
{
    public abstract class LoggingStartupBase : LoggedStartup
    {
        protected LoggingStartupBase(ILogger logger)
            : base(logger)
        {
        }

        public override async Task ConfigureConfiguration(IConfigurationBuilder configurationBuilder, IServiceProvider startupServicesProvider)
        {
            await base.ConfigureConfiguration(configurationBuilder, startupServicesProvider);

            this.Logger.LogDebug("Starting configuration of configuration builder...");

            await this.ConfigureConfiguration_HasLogging(configurationBuilder, startupServicesProvider);

            this.Logger.LogDebug("Finished configuration of configuration builder.");
        }

        protected abstract Task ConfigureConfiguration_HasLogging(IConfigurationBuilder configurationBuilder, IServiceProvider startupServicesProvider);

        public override async Task ConfigureServices(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider)
        {
            await base.ConfigureServices(services, configurationAction, startupServicesProvider);

            this.Logger.LogDebug("Starting configuration of service collection...");

            await this.ConfigureServices_HasLogging(services, configurationAction, startupServicesProvider);

            this.Logger.LogDebug("Finished configuration of service collection.");
        }

        protected abstract Task ConfigureServices_HasLogging(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider);
    }
}
