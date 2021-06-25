using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;


namespace R5T.T0027.Configuration.T001
{
    public static class IConfigurationBuilderExtensions
    {
        public static async Task<IConfigurationBuilder> AddDefaultAndEnvironmentNameSpecificAppSettingsFilePaths(this Task<IConfigurationBuilder> gettingConfigurationBuilder,
            IServiceProvider startupServicesProvider)
        {
            var configurationBuilder = await gettingConfigurationBuilder;

            await startupServicesProvider.Run<AddDefaultAndEnvironmentNameSpecificAppSettingsFilePaths, IConfigurationBuilder>(configurationBuilder);

            return configurationBuilder;
        }
    }
}
