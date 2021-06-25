using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using R5T.Suebia;

using R5T.T0020;


namespace R5T.T0027.Configuration.SecretsFilePaths
{
    public class AddSecretsJsonFilePath : IActionOperation<IConfigurationBuilder, string>
    {
        private ISecretsDirectoryFilePathProvider SecretsDirectoryFilePathProvider { get; }


        public AddSecretsJsonFilePath(
            ISecretsDirectoryFilePathProvider secretsDirectoryFilePathProvider)
        {
            this.SecretsDirectoryFilePathProvider = secretsDirectoryFilePathProvider;
        }

        public async Task Run(IConfigurationBuilder configurationBuilder, string secretsFileName)
        {
            var secretsFilePath = await this.SecretsDirectoryFilePathProvider.GetSecretsFilePath(secretsFileName);

            configurationBuilder.AddJsonFile(secretsFilePath);
        }
    }
}
