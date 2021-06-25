using System;

using R5T.Dacia;
using R5T.Lombardy;

using R5T.D0070;
using R5T.D0063;
using R5T.D0065;
using R5T.D0071.ExecutingAssembly;


namespace R5T.T0027.A003
{
    public class ServicesAggregation01 : IServicesAggregation01
    {
        public IServiceAction<IAppSettingsFilePathProvider> AppSettingsFilePathProvider { get; set; }
        public IServiceAction<IAppSettingsDirectoryPathProvider> AppSettingsDirectoryPathProviderAction { get; set; }
        public IServiceAction<IAppSettingsFileNameProvider> AppSettingsFileNameProviderAction { get; set; }
        public IServiceAction<IEnvironmentVariableProvider> EnvironmentVariableProviderAction { get; set; }
        public IServiceAction<IEnvironmentVariablesProvider> EnvironmentVariablesProviderAction { get; set; }
        public IServiceAction<IExecutableDirectoryPathProvider> ExecutableDirectoryPathProviderAction { get; set; }
        public IServiceAction<IFilePathProvider> ExecutingAssemblyFilePathProviderAction { get; set; }
        public IServiceAction<IDirectoryNameOperator> DirectoryNameOperatorAction { get; set; }
        public IServiceAction<IDirectorySeparatorOperator> DirectorySeparatorOperatorAction { get; set; }
        public IServiceAction<IFileExtensionOperator> FileExtensionOperatorAction { get; set; }
        public IServiceAction<IFileNameOperator> FileNameOperatorAction { get; set; }
        public IServiceAction<IStringlyTypedPathOperator> StringlyTypedPathOperatorAction { get; set; }
    }
}
