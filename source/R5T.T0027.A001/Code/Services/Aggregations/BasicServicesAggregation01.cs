using System;

using R5T.Dacia;
using R5T.Lombardy;
using R5T.Suebia.Standard;

using R5T.D0065.Standard;
using R5T.D0070.Standard;


namespace R5T.T0027.A001
{
    public class BasicServicesAggregation01
    {
        public AppSettingsFilePathAggregation01 AppSettingsFilePathServices { get; set; }
        public ExecutableDirectoryPathAggregation02 ExecutableDirectoryPathServices { get; set; }
        public PathRelatedOperatorsAggregation01 PathRelatedOperators { get; set; }
        public SecretsDirectoryFilePathAggregation01 SecretsDirectoryFilePathServices { get; set; }
    }
}
