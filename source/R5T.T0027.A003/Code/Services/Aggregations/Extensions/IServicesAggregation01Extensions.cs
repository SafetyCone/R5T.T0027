using System;

using R5T.Lombardy;

using R5T.D0063.Default;
using R5T.D0065.Standard;
using R5T.D0070.Default;

using R5T.T0027.A003;


namespace System
{
    public static class IServicesAggregation01Extensions
    {
        public static T FillFrom<T>(this T aggregtion,
            IServicesAggregation01 other)
            where T : IServicesAggregation01
        {
            (aggregtion as IDefaultAppSettingsFilePathAggregation01).FillFrom(other);
            (aggregtion as IEnvironmentVariableProvidersAggregation01).FillFrom(other);
            (aggregtion as IExecutableDirectoryPathAggregation02).FillFrom(other);
            (aggregtion as IPathRelatedOperatorsAggregation01).FillFrom(other);

            return aggregtion;
        }
    }
}
