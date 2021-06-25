using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.Suebia;


namespace R5T.T0027.Configuration.SecretsFilePaths
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="AddSecretsJsonFilePath"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddAddSecretsJsonFilePath(this IServiceCollection services,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction)
        {
            services.AddSingleton<AddSecretsJsonFilePath>()
                .Run(secretsDirectoryFilePathProviderAction);

            return services;
        }

        /// <summary>
        /// Adds the <see cref="AddSecretsJsonFilePath"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<AddSecretsJsonFilePath> AddAddSecretsJsonFilePathAction(this IServiceCollection services,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction)
        {
            var serviceAction = ServiceAction.New<AddSecretsJsonFilePath>(() => services.AddAddSecretsJsonFilePath(
                secretsDirectoryFilePathProviderAction));

            return serviceAction;
        }
    }
}
