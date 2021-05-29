using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using R5T.T0027.Configuration.DefaultAppSettings;

using StartupBase = R5T.Plymouth.Startup.Startup;


namespace R5T.T0027.T003
{
    public class Startup : StartupBase
    {
        public override async Task ConfigureConfiguration(IConfigurationBuilder configurationBuilder, IServiceProvider startupServicesProvider)
        {
            await base.ConfigureConfiguration(configurationBuilder, startupServicesProvider);

            configurationBuilder.AddDefaultJsonAppSettingsFile();
        }
    }
}
