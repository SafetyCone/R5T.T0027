using System;


namespace R5T.T0027.T008
{
    public static class IRequiredServicesExtensions
    {
        public static T FillFrom<T>(this T value,
            IRequiredServices other)
            where T : IRequiredServices
        {
            value.OrganizationProviderAction = other.OrganizationProviderAction;

            return value;
        }
    }
}
