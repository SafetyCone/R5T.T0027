using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using R5T.T0020;


namespace R5T.T0027.Construction.Operations
{
    public class GetConfiguration : IOperation
    {
        private IConfiguration Configuration { get; }


        public GetConfiguration(
            IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public Task Run()
        {
            var key = "ConfigurationName";
            var value = this.Configuration.GetRequiredValue(key);

            Console.WriteLine($"Configuration - \"{key}\":\"{value}\"");

            return Task.CompletedTask;
        }
    }
}
