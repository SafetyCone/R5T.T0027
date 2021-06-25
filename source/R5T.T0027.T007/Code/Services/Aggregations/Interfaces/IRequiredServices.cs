using System;

using R5T.Dacia;
using R5T.Ostrogothia;


namespace R5T.T0027.T007
{
    public interface IRequiredServices
    {
        IServiceAction<IOrganizationProvider> OrganizationProviderAction { get; set; }
    }
}
