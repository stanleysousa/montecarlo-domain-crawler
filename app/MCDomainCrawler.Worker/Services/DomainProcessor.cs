using MCDomainCrawler.Core;
using MCDomainCrawler.Infrastructure;
using MCDomainCrawler.Worker.Services.Interfaces;
using MCDomainCrawler.Worker.Extensions;
using MCDomainCrawler.Worker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace MCDomainCrawler.Worker.Services
{
    public class DomainProcessor : IDomainProcessor
    {
        private readonly IOptions<Config> _config;
        private readonly ILogger<DomainProcessor> _logger;
        public DomainProcessor(IOptions<Config> config, ILogger<DomainProcessor> logger)
        {
            _config = config;
            _logger = logger;
        }

        (Dictionary<int, double> estimates, Dictionary<int, string> found) IDomainProcessor.Process()
        {
            var domain = _config.Value.Domain;
            var k = _config.Value.WordLength;
            var n = _config.Value.Samples;

            var coefficient = Base26.countWords(k);
            var estimates = new Dictionary<int, double>();
            var subdomains = new Dictionary<int, string>();

            var sumH = 0;
            var words = RandomNumberGenerator.createDiscreteSamples(n, coefficient).Select(w => w.ToBase26Word());

            for (int i = 0; i < words.Count(); i++)
            {
                var uri = "http://www."+words.ElementAt(i)+"."+domain;
                if(QueryWebDomain.WebDomainExists(uri))
                {
                    subdomains.Add(i, words.ElementAt(i));
                    sumH ++;
                    estimates.Add(i, (coefficient/n)*sumH);
                    _logger.LogDebug(words.ElementAt(i) + " found on n=" + i.ToString());
                }
                else
                {
                    _logger.LogDebug(words.ElementAt(i) + " is invalid");
                }
            }
            _logger.LogDebug("Found: " + subdomains.Count.ToString() + " subdomains");
            return(estimates, subdomains);
        }
    }
}