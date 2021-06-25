using System;

using R5T.Dacia;
using R5T.Ostrogothia;


namespace R5T.T0027.T008
{
    public class RequiredServices : IRequiredServices
    {
        public IServiceAction<IOrganizationProvider> OrganizationProviderAction { get; set; }
    }
}
