using System;
using System.Linq;
using System.Threading.Tasks;
using DataHandler;
using Microsoft.FSharp.Collections;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Worker.Services.Interfaces;


namespace Worker
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var services = new ServiceCollection();
            new Startup().ConfigureServices(services);
            await ExecuteAsync(services.BuildServiceProvider());
            return 0;
        }

        private static async Task ExecuteAsync(IServiceProvider serviceProvider)
        {
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            logger.LogInformation("Running...");

            var (estimates, subdomains) = await serviceProvider.GetService<IDomainProcessor>().Process();

            estimates.TryGetValue(estimates.Keys.Max(), out var estimate);
            logger.LogInformation("Estimated number of subdomains: " + estimate.ToString());

            //Plot estimates over n
            Plot.line(ListModule.OfSeq(estimates.Keys), ListModule.OfSeq(estimates.Values), "");
            logger.LogInformation("Done.");
        }
    }
}
