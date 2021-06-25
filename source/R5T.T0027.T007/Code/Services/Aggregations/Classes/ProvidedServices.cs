using System;

using R5T.Dacia;
using R5T.Ostrogothia;


namespace R5T.T0027.T007
{
    public class ProvidedServices : A004.ServicesAggregation01, IProvidedServices
    {
        public IServiceAction<IOrganizationProvider> OrganizationProviderAction { get; set; }
    }
}
