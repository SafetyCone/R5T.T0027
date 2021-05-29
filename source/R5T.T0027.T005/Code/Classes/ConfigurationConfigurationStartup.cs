using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using R5T.T0027.Configuration.DefaultAppSettings;


namespace R5T.T0027.T005
{
    public class ConfigurationConfigurationStartup : T001.ZeroServiceDependenciesStartup
    {
        public override async Task ConfigureConfiguration(IConfigurationBuilder configurationBuilder, IServiceProvider startupServicesProvider)
        {
            await base.ConfigureConfiguration(configurationBuilder, startupServicesProvider);

            configurationBuilder.AddDefaultJsonAppSettingsFile();
        }
    }
}
