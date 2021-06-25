using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;

using R5T.D0062;
using R5T.D0062.Chamavia;
using R5T.D0065.Standard;
using R5T.D0070.Default;


namespace R5T.T0027.A002
{
    public class AppSettingsServicesAggregation01
    {
        public IServiceAction<IDefaultEnvironmentNameProvider> DefaultEnvironmentNameProvider { get; set; }
        public PathRelatedOperatorsAggregation01 PathRelatedOperatorServices { get; set; }
        public EnvironmentNameProviderAggregation01 EnvironmentNameProviderServices { get; set; }
        public ExecutableDirectoryPathAggregation02 ExecutableDirectoryPathServices { get; set; }
        public DefaultAppSettingsFilePathAggregation01 DefaultAppSettingsFilePathServices { get; set; }
        public EnvironmentNameSpecificAppSettingsFilePathAggregation01 EnvironmentNameSpecificAppSettingsFilePathServices { get; set; }
    }
}
