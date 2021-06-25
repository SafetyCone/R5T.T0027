using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Suebia;
using R5T.Suebia.Quadia;

using R5T.D0065;
using R5T.D0070;
using R5T.D0073;

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

        /// <summary>
        /// Adds the <see cref="ExerciseAppSettingsServices"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddExerciseAppSettingsServices(this IServiceCollection services,
            IServiceAction<IAppSettingsFilePathProvider> appSettingsFilePathProviderAction,
            IServiceAction<IEnvironmentNameSpecificAppSettingsFilePathProvider> environmentNameSpecificAppSettingsFilePathProviderAction)
        {
            services.AddSingleton<ExerciseAppSettingsServices>()
                .Run(appSettingsFilePathProviderAction)
                .Run(environmentNameSpecificAppSettingsFilePathProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ExerciseAppSettingsServices"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ExerciseAppSettingsServices> AddExerciseAppSettingsServicesAction(this IServiceCollection services,
            IServiceAction<IAppSettingsFilePathProvider> appSettingsFilePathProviderAction,
            IServiceAction<IEnvironmentNameSpecificAppSettingsFilePathProvider> environmentNameSpecificAppSettingsFilePathProviderAction)
        {
            var serviceAction = ServiceAction.New<ExerciseAppSettingsServices>(() => services.AddExerciseAppSettingsServices(
                appSettingsFilePathProviderAction,
                environmentNameSpecificAppSettingsFilePathProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ExerciseMachineLocationAwareSecretsDirectory"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddExerciseMachineLocationAwareSecretsDirectory(this IServiceCollection services,
            IServiceAction<IMachineLocationProvider> machineLocationProviderAction,
            IServiceAction<IOrganizationDataSecretsDirectoryPathProvider> organizationDataSecretsDirectoryPathProviderAction,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction)
        {
            services.AddSingleton<ExerciseMachineLocationAwareSecretsDirectory>()
                .Run(machineLocationProviderAction)
                .Run(organizationDataSecretsDirectoryPathProviderAction)
                .Run(secretsDirectoryFilePathProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ExerciseMachineLocationAwareSecretsDirectory"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ExerciseMachineLocationAwareSecretsDirectory> AddExerciseMachineLocationAwareSecretsDirectoryAction(this IServiceCollection services,
            IServiceAction<IMachineLocationProvider> machineLocationProviderAction,
            IServiceAction<IOrganizationDataSecretsDirectoryPathProvider> organizationDataSecretsDirectoryPathProviderAction,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction)
        {
            var serviceAction = ServiceAction.New<ExerciseMachineLocationAwareSecretsDirectory>(() => services.AddExerciseMachineLocationAwareSecretsDirectory(
                machineLocationProviderAction,
                organizationDataSecretsDirectoryPathProviderAction,
                secretsDirectoryFilePathProviderAction));

            return serviceAction;
        }
    }
}
