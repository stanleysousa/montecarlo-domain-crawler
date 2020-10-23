using MCDomainCrawler.Infrastructure;
using MCDomainCrawler.Worker.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.FSharp.Collections;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace MCDomainCrawler.Worker
{
    class Program
    {
        static int Main(string[] args)
        {
            var services = new ServiceCollection();
            new Startup().ConfigureServices(services);
            Execute(services.BuildServiceProvider());
            return 0;
        }

        private static void Execute(IServiceProvider serviceProvider)
        {
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            logger.LogInformation("Running...");

            var result = serviceProvider.GetService<IDomainProcessor>().Process();

            result.estimates.TryGetValue(result.estimates.Keys.Max(), out var estimate);
            logger.LogInformation("Estimated number of subdomains: " + estimate.ToString());

            //Plot estimates over n
            Plot.line(ListModule.OfSeq(result.estimates.Keys), ListModule.OfSeq(result.estimates.Values), "");
            logger.LogInformation("Done.");
        }
    }
}
