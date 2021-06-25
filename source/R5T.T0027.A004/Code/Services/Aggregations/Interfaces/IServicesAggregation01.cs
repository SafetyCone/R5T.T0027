using System;

using R5T.Suebia.Standard;

using R5T.D0073.Standard;


namespace R5T.T0027.A004
{
    public interface IServicesAggregation01 : A003.IServicesAggregation01, IServicesAggregation01Increment,
        IOrganizationDataSecretsDirectoryPathAggregation01,
        IMachineLocationProviderAggregation01
    {
    }
}
