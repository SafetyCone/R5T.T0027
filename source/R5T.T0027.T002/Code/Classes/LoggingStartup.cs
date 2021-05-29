using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Dacia;


namespace R5T.T0027.T002
{
    public class LoggingStartup : LoggingStartupBase
    {
        public LoggingStartup(ILogger<LoggingStartup> logger)
            : base(logger)
        {
        }

        /// <summary>
        /// Base method does nothing.
        /// </summary>
        protected override Task ConfigureConfiguration_HasLogging(IConfigurationBuilder configurationBuilder, IServiceProvider startupServicesProvider)
        {
            // Do nothing.

            return Task.CompletedTask;
        }

        /// <summary>
        /// Base method does nothing.
        /// </summary>
        protected override Task ConfigureServices_HasLogging(IServiceCollection services, IServiceAction<IConfiguration> configurationAction, IServiceProvider startupServicesProvider)
        {
            // Do nothing.

            return Task.CompletedTask;
        }
    }
}
