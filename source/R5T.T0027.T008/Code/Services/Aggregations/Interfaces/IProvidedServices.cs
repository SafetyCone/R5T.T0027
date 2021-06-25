using System;

using Microsoft.Extensions.Logging;

using R5T.Dacia;


namespace R5T.T0027.T008
{
    public interface IProvidedServices : A001.IServicesAggregation01, IProvidedServicesIncrement
    {
        public IServiceAction<ILogger> LoggerAction { get; set; }
    }
}
