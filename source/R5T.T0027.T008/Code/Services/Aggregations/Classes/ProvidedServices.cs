using System;

using Microsoft.Extensions.Logging;

using R5T.Dacia;
using R5T.Ostrogothia;


namespace R5T.T0027.T008
{
    public class ProvidedServices : A001.ServicesAggregation01, IProvidedServices
    {
        public IServiceAction<ILogger> LoggerAction { get; set; }
        public IServiceAction<IOrganizationProvider> OrganizationProviderAction { get; set; }
    }
}
