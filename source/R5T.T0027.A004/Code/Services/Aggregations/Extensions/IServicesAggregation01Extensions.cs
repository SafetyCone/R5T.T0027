using System;

using R5T.Magyar.Extensions;

using R5T.D0073.Standard;
using R5T.Suebia.Standard;

using R5T.T0027.A004;


namespace System
{
    public static class IServicesAggregation01Extensions
    {
        public static T FillFrom<T>(this T aggregation,
            IServicesAggregation01 other)
            where T : IServicesAggregation01
        {
            (aggregation as R5T.T0027.A003.IServicesAggregation01).FillFrom(other);
            (aggregation as IOrganizationDataSecretsDirectoryPathAggregation01).FillFrom(other);
            (aggregation as IMachineLocationProviderAggregation01).FillFrom(other);

            aggregation.ModifyAs<IServicesAggregation01, IServicesAggregation01Increment>(increment =>
            {
                increment.SecretsDirectoryFilePathProviderAction = other.SecretsDirectoryFilePathProviderAction;
                increment.SecretsDirectoryPathProviderAction = other.SecretsDirectoryPathProviderAction;
            });

            return aggregation;
        }
    }
}
