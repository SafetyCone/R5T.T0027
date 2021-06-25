using System;

using R5T.Dacia;
using R5T.Suebia;


namespace R5T.T0027.A004
{
    public interface IServicesAggregation01Increment
    {
        public IServiceAction<ISecretsDirectoryPathProvider> SecretsDirectoryPathProviderAction { get; set; }
        public IServiceAction<ISecretsDirectoryFilePathProvider> SecretsDirectoryFilePathProviderAction { get; set; }
    }
}
