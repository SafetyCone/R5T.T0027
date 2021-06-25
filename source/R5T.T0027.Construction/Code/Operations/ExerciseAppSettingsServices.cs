using System;
using System.Threading.Tasks;

using R5T.T0020;

using R5T.D0070;


namespace R5T.T0027.Construction.Operations
{
    public class ExerciseAppSettingsServices : IOperation
    {
        private IAppSettingsFilePathProvider AppSettingsFilePathProvider { get; }
        private IEnvironmentNameSpecificAppSettingsFilePathProvider EnvironmentNameSpecificAppSettingsFilePathProvider { get; }


        public ExerciseAppSettingsServices(
            IAppSettingsFilePathProvider appSettingsFilePathProvider,
            IEnvironmentNameSpecificAppSettingsFilePathProvider environmentNameSpecificAppSettingsFilePathProvider)
        {
            this.AppSettingsFilePathProvider = appSettingsFilePathProvider;
            this.EnvironmentNameSpecificAppSettingsFilePathProvider = environmentNameSpecificAppSettingsFilePathProvider;
        }

        public async Task Run()
        {
            var appSettingsFilePath = await this.AppSettingsFilePathProvider.GetAppSettingsFilePath();
            var environmentNameSpecificAppSettingsFilePath = await this.EnvironmentNameSpecificAppSettingsFilePathProvider.GetAppSettingsFilePath();

            Console.WriteLine($"AppSettings file path:\n\t{appSettingsFilePath}");
            Console.WriteLine($"Environment name-specific AppSettings file path:\n\t{environmentNameSpecificAppSettingsFilePath}");
        }
    }
}
