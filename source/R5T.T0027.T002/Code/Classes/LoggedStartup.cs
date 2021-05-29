using System;

using Microsoft.Extensions.Logging;

using StartupBase = R5T.Plymouth.Startup.Startup;


namespace R5T.T0027.T002
{
    public class LoggedStartup : StartupBase
    {
        protected ILogger Logger { get; }


        public LoggedStartup(
            ILogger logger)
            : base()
        {
            this.Logger = logger;
        }
    }
}
