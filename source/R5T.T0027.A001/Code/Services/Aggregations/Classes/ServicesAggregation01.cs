using System;

using R5T.Bulgaria;
using R5T.Carpathia;
using R5T.Costobocia;
using R5T.Dacia;
using R5T.Quadia;
using R5T.Suebia;
using R5T.Visigothia;

using R5T.D0070;

using IOrganizationDirectoryPathProvider = R5T.Carpathia.IOrganizationDirectoryPathProvider;
using IOrganizationalDirectoryPathProvider = R5T.Costobocia.IOrganizationDirectoryPathProvider;


namespace R5T.T0027.A001
{
    public class ServicesAggregation01 : A003.ServicesAggregation01, IServicesAggregation01
    {
        public IServiceAction<IAppSettingsFileNameStemTokenizationConvention> AppSettingsFileNameStemTokenizationConventionAction { get; set; }
        public IServiceAction<IEnvironmentNameToAppSettingsFileNameTokenConverter> EnvironmentNameToAppSettingsFileNameTokenConverterAction { get; set; }
        public IServiceAction<IEnvironmentNameSpecificAppSettingsFileNameProvider> EnvironmentNameSpecificAppSettingsFileNameProviderAction { get; set; }
        public IServiceAction<IEnvironmentNameSpecificAppSettingsFilePathProvider> EnvironmentNameSpecificAppSettingsFilePathProviderAction { get; set; }
        public IServiceAction<ISecretsDirectoryFilePathProvider> SecretsDirectoryFilePathProviderAction { get; set; }
        public IServiceAction<ISecretsDirectoryPathProvider> SecretsDirectoryPathProviderAction { get; set; }
        public IServiceAction<IOrganizationDataDirectoryPathProvider> OrganizationDataDirectoryPathProviderAction { get; set; }
        public IServiceAction<IOrganizationDirectoryPathProvider> OrganizationDirectoryPathProviderAction { get; set; }
        public IServiceAction<ISharedOrganizationDirectoryPathProvider> SharedOrganizationDirectoryPathProviderAction { get; set; }
        public IServiceAction<ISharedDirectoryNameProvider> SharedDirectoryNameProviderAction { get; set; }
        public IServiceAction<IOrganizationalDirectoryPathProvider> OrganizationalDirectoryPathProviderAction { get; set; }
        public IServiceAction<IOrganizationDirectoryNameProvider> OrganizationDirectoryNameProviderAction { get; set; }
        public IServiceAction<IOrganizationsDirectoryPathProvider> OrganizationsDirectoryPathProviderAction { get; set; }
        public IServiceAction<IOrganizationsDirectoryNameProvider> OrganizationsDirectoryNameProviderAction { get; set; }
        public IServiceAction<IDropboxDirectoryPathProvider> DropboxDirectoryPathProviderAction { get; set; }
        public IServiceAction<IDropboxDirectoryNameProvider> DropboxDirectoryNameProviderAction { get; set; }
        public IServiceAction<IUserProfileDirectoryPathProvider> UserProfileDirectoryPathProviderAction { get; set; }
    }
}
