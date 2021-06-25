using System;

using Microsoft.Extensions.Logging;


namespace R5T.T0027.T002
{
    public class LoggedStartup : LoggedStartupBase
    {
        public LoggedStartup(
            ILogger<LoggedStartup> logger)
            : base(logger)
        {
        }
    }
}
