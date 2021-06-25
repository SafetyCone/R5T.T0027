using System;

using R5T.Lombardy;

using R5T.D0063.Default;
using R5T.D0065.Standard;
using R5T.D0070.Default;


namespace R5T.T0027.A003
{
    public interface IServicesAggregation01 :
        IDefaultAppSettingsFilePathAggregation01,
        IEnvironmentVariableProvidersAggregation01,
        IExecutableDirectoryPathAggregation02,
        IPathRelatedOperatorsAggregation01
    {
    }
}
