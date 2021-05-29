using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Suebia;

using R5T.D0065;
using R5T.D0070;

using R5T.T0027.Construction.Operations;


namespace R5T.T0027.Construction
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="GetConfiguration"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGetConfiguration(this IServiceCollection services,
            IServiceAction<IConfiguration> configurationAction)
        {
            services.AddSingleton<GetConfiguration>()
                .Run(configurationAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GetConfiguration"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<GetConfiguration> AddGetConfigurationAction(this IServiceCollection services,
            IServiceAction<IConfiguration> configurationAction)
        {
            var serviceAction = ServiceAction.New<GetConfiguration>(() => services.AddGetConfiguration(
                configurationAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ExerciseBasicServices"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddExerciseBasicServices(this IServiceCollection services,
            IServiceAction<IAppSettingsFilePathProvider> appSettingsFilePathProviderAction,
            IServiceAction<IExecutableDirectoryPathProvider> executableDirectoryPathProviderAction,
            IServiceAction<ISecretsDirectoryPathProvider> secretsDirectoryPathProviderAction)
        {
            services.AddSingleton<ExerciseBasicServices>()
                .Run(appSettingsFilePathProviderAction)
                .Run(executableDirectoryPathProviderAction)
                .Run(secretsDirectoryPathProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ExerciseBasicServices"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ExerciseBasicServices> AddExerciseBasicServicesAction(this IServiceCollection services,
            IServiceAction<IAppSettingsFilePathProvider> appSettingsFilePathProviderAction,
            IServiceAction<IExecutableDirectoryPathProvider> executableDirectoryPathProviderAction,
            IServiceAction<ISecretsDirectoryPathProvider> secretsDirectoryPathProviderAction)
        {
            var serviceAction = ServiceAction.New<ExerciseBasicServices>(() => services.AddExerciseBasicServices(
                appSettingsFilePathProviderAction,
                executableDirectoryPathProviderAction,
                secretsDirectoryPathProviderAction));

            return serviceAction;
        }
    }
}
