using System;

using Microsoft.Extensions.Logging;

using StartupBase = R5T.Plymouth.Startup.Startup;


namespace R5T.T0027.T002
{
    public abstract class LoggedStartupBase : StartupBase
    {
        protected ILogger Logger { get; }


        public LoggedStartupBase(
            ILogger logger)
            : base()
        {
            this.Logger = logger;
        }
    }
}
