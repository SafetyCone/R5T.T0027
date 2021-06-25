using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;


namespace R5T.T0027.Configuration.SecretsFilePaths
{
    public static class IConfigurationBuilderExtensions
    {
        public static async Task<IConfigurationBuilder> AddSecretsFilePath(this IConfigurationBuilder configurationBuilder,
            string secretsFileName, IServiceProvider startupServicesProvider)
        {
            await startupServicesProvider.Run<AddSecretsJsonFilePath, IConfigurationBuilder, string>(configurationBuilder, secretsFileName);

            return configurationBuilder;
        }
    }
}
