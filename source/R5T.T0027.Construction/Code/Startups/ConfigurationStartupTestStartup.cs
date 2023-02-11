using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using R5T.Magyar.Extensions;

using R5T.T0027.Configuration.T001;


namespace R5T.T0027.Construction
{
    public class ConfigurationStartupTestStartup : Plymouth.Startup.Startup
    {
        public override async Task ConfigureConfiguration(IConfigurationBuilder configurationBuilder, IServiceProvider startupServicesProvider)
        {
            await base.ConfigureConfiguration(configurationBuilder, startupServicesProvider);

            await configurationBuilder.AsTask()
                .AddDefaultAndEnvironmentNameSpecificAppSettingsFilePaths(startupServicesProvider)
                ;
        }
    }
}
