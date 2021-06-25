using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.D0070;


namespace R5T.T0027.Configuration.T001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="AddDefaultAndEnvironmentNameSpecificAppSettingsFilePaths"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddAddDefaultAndEnvironmentNameSpecificAppSettingsFilePaths(this IServiceCollection services,
            IServiceAction<IAppSettingsFilePathProvider> appSettingsFilePathProviderAction,
            IServiceAction<IEnvironmentNameSpecificAppSettingsFilePathProvider> environmentNameSpecificAppSettingsFilePathProviderAction)
        {
            services.AddSingleton<AddDefaultAndEnvironmentNameSpecificAppSettingsFilePaths>()
                .Run(appSettingsFilePathProviderAction)
                .Run(environmentNameSpecificAppSettingsFilePathProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="AddDefaultAndEnvironmentNameSpecificAppSettingsFilePaths"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<AddDefaultAndEnvironmentNameSpecificAppSettingsFilePaths> AddAddDefaultAndEnvironmentNameSpecificAppSettingsFilePathsAction(this IServiceCollection services,
            IServiceAction<IAppSettingsFilePathProvider> appSettingsFilePathProviderAction,
            IServiceAction<IEnvironmentNameSpecificAppSettingsFilePathProvider> environmentNameSpecificAppSettingsFilePathProviderAction)
        {
            var serviceAction = ServiceAction.New<AddDefaultAndEnvironmentNameSpecificAppSettingsFilePaths>(() => services.AddAddDefaultAndEnvironmentNameSpecificAppSettingsFilePaths(
                appSettingsFilePathProviderAction,
                environmentNameSpecificAppSettingsFilePathProviderAction));

            return serviceAction;
        }
    }
}
