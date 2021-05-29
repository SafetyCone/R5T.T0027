using System;

using StartupBase = R5T.Plymouth.Startup.Startup;


namespace R5T.T0027.T001
{
    /// <summary>
    /// Startup class with zero service dependencies. The name of the class explicitly communicates that its constructor, and the constructors of any derived classes, should require no services.
    /// This means the startup class has zero service dependencies. (As opposed to a startup class that might require an ILogger, or other service when created from a service provider).
    /// This class is useful in the initial stage of a multi-stage startup process when no services are available.
    /// </summary>
    public class ZeroServiceDependenciesStartup : StartupBase
    {
    }
}
