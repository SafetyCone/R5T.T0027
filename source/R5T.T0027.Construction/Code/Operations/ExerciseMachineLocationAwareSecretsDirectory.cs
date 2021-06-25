using System;
using System.Threading.Tasks;

using R5T.T0020;

using R5T.Suebia;
using R5T.Suebia.Quadia;

using R5T.D0073;


namespace R5T.T0027.Construction.Operations
{
    public class ExerciseMachineLocationAwareSecretsDirectory : IOperation
    {
        private IMachineLocationProvider MachineLocationProvider { get; }
        private IOrganizationDataSecretsDirectoryPathProvider OrganizationDataSecretsDirectoryPathProvider { get; }
        private ISecretsDirectoryFilePathProvider SecretsDirectoryFilePathProvider { get; }


        public ExerciseMachineLocationAwareSecretsDirectory(
            IMachineLocationProvider machineLocationProvider,
            IOrganizationDataSecretsDirectoryPathProvider organizationDataSecretsDirectoryPathProvider,
            ISecretsDirectoryFilePathProvider secretsDirectoryFilePathProvider)
        {
            this.MachineLocationProvider = machineLocationProvider;
            this.OrganizationDataSecretsDirectoryPathProvider = organizationDataSecretsDirectoryPathProvider;
            this.SecretsDirectoryFilePathProvider = secretsDirectoryFilePathProvider;
        }

        public async Task Run()
        {
            var machineLocation = await this.MachineLocationProvider.GetMachineLocation();
            var organizationDataSecretsDirectoryPath = await this.OrganizationDataSecretsDirectoryPathProvider.GetSecretsDirectoryPath();
            var secretsFilePath = await this.SecretsDirectoryFilePathProvider.GetSecretsFilePath("secrets.json");

            Console.WriteLine($"Machine location: {machineLocation}");
            Console.WriteLine($"Organization/Data/Secrets directory path: {organizationDataSecretsDirectoryPath}");
            Console.WriteLine($"File path for secrets.json: {secretsFilePath}");
        }
    }
}
