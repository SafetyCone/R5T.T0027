using System;

using Microsoft.Extensions.Configuration;

using R5T.D0070;


namespace R5T.T0027.Configuration.DefaultAppSettings
{
    public static class IConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddDefaultJsonAppSettingsFile(this IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.AddJsonFile(AppSettingsFile.DefaultJsonFileName);

            return configurationBuilder;
        }
    }
}
