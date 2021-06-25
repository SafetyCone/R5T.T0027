using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using R5T.T0020;

using R5T.D0070;


namespace R5T.T0027.Configuration.T001
{
    public class AddDefaultAndEnvironmentNameSpecificAppSettingsFilePaths : IActionOperation<IConfigurationBuilder>
    {
        private IAppSettingsFilePathProvider AppSettingsFilePathProvider { get; }
        private IEnvironmentNameSpecificAppSettingsFilePathProvider EnvironmentNameSpecificAppSettingsFilePathProvider { get; }


        public AddDefaultAndEnvironmentNameSpecificAppSettingsFilePaths(
            IAppSettingsFilePathProvider appSettingsFilePathProvider,
            IEnvironmentNameSpecificAppSettingsFilePathProvider environmentNameSpecificAppSettingsFilePathProvider)
        {
            this.AppSettingsFilePathProvider = appSettingsFilePathProvider;
            this.EnvironmentNameSpecificAppSettingsFilePathProvider = environmentNameSpecificAppSettingsFilePathProvider;
        }

        public async Task Run(IConfigurationBuilder configurationBuilder)
        {
            var appSettingsFilePath = await this.AppSettingsFilePathProvider.GetAppSettingsFilePath();
            var environmentNameSpecificAppSettingsFilePath = await this.EnvironmentNameSpecificAppSettingsFilePathProvider.GetAppSettingsFilePath();

            configurationBuilder
                .AddJsonFile(appSettingsFilePath)
                .AddJsonFile(environmentNameSpecificAppSettingsFilePath)
                ;
        }
    }
}
