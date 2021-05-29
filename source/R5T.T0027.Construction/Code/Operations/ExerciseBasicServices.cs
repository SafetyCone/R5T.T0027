using System;
using System.Threading.Tasks;

using R5T.Suebia;

using R5T.T0020;

using R5T.D0065;
using R5T.D0070;


namespace R5T.T0027.Construction.Operations
{
    public class ExerciseBasicServices : IOperation
    {
        private IAppSettingsFilePathProvider AppSettingsFilePathProvider { get; }
        private IExecutableDirectoryPathProvider ExecutableDirectoryPathProvider { get; }
        private ISecretsDirectoryPathProvider SecretsDirectoryPathProvider { get; }


        public ExerciseBasicServices(
            IAppSettingsFilePathProvider appSettingsFilePathProvider,
            IExecutableDirectoryPathProvider executableDirectoryPathProvider,
            ISecretsDirectoryPathProvider secretsDirectoryPathProvider)
        {
            this.AppSettingsFilePathProvider = appSettingsFilePathProvider;
            this.ExecutableDirectoryPathProvider = executableDirectoryPathProvider;
            this.SecretsDirectoryPathProvider = secretsDirectoryPathProvider;
        }

        public async Task Run()
        {
            var appSettingsFilePath = await this.AppSettingsFilePathProvider.GetAppSettingsFilePath();
            var executableDirectoryPath = await this.ExecutableDirectoryPathProvider.GetExecutableDirectoryPath();
            var secretsDirectoryPath = await this.SecretsDirectoryPathProvider.GetSecretsDirectoryPath();

            Console.WriteLine($"AppSettings file path:\n\t{appSettingsFilePath}");
            Console.WriteLine($"Executable directory path:\n\t{executableDirectoryPath}");
            Console.WriteLine($"Secrets directory path:\n\t{secretsDirectoryPath}");
        }
    }
}
