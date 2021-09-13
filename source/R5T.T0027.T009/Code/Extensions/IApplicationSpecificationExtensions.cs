using System;
using System.Threading.Tasks;

using R5T.Plymouth;

using R5T.T0027.T009;


namespace System
{
    public static class IApplicationSpecificationExtensions
    {
        public static Task<IApplicationSpecification> UseT0027_T009_TwoStageStartup<TStartup>(this Task<IApplicationSpecification> gettingApplicationSpecification)
            where TStartup : Startup
        {
            var output = gettingApplicationSpecification
                .UseStartup<TStartup>(() =>
                {
                    return ApplicationBuilder.Instance
                        .NewApplication()
                        .UseStartup<Startup>(startupProviderServices =>
                        {
                            startupProviderServices.AddDefaultLogging();

                            return Task.CompletedTask;
                        })
                        .BuildServiceProvider();
                },
                startupProviderServices =>
                {
                    startupProviderServices.AddDefaultLogging();

                    return Task.CompletedTask;
                });

            return output;
        }
    }
}
