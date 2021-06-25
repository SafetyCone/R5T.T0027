using System;

using R5T.Suebia.Standard;

using R5T.T0027.A001;


namespace System
{
    public static class IServicesAggregation01Extensions
    {
        public static T FillFrom<T>(this T aggregtion,
            IServicesAggregation01 other)
            where T : IServicesAggregation01
        {
            (aggregtion as R5T.T0027.A003.IServicesAggregation01).FillFrom(other);
            (aggregtion as ISecretsDirectoryFilePathAggregation01).FillFrom(other);

            return aggregtion;
        }
    }
}
