using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Worker.Services.Interfaces;
using Worker.Extensions;
using Worker.Models;
using DataHandler;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace Worker.Services
{
    public class DomainProcessor : IDomainProcessor
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<Config> _config;
        private readonly ILogger<DomainProcessor> _logger;
        public DomainProcessor(IOptions<Config> config, ILogger<DomainProcessor> logger)
        {
            _httpClient = new HttpClient();
            _config = config;
            _logger = logger;
        }
        private async Task<bool> Indicator(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Head, uri);
            try
            {
                HttpResponseMessage response = await _httpClient.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch(HttpRequestException)
            {
                return false;
            }
        }

        async Task<(Dictionary<int, double> estimates, Dictionary<int, string> found)> IDomainProcessor.Process()
        {
            var domain = _config.Value.Domain;
            var k = _config.Value.WordLength;
            var n = _config.Value.Samples;

            var absX = Base26Word.WordCount(k);
            var estimates = new Dictionary<int, double>();
            var subdomains = new Dictionary<int, string>();

            var sumH = 0;
            var words = NumberGenerator.G(n, absX).Select(w => w.FromBase26());

            for (int i = 0; i < words.Count(); i++)
            {
                var uri = "http://www."+words.ElementAt(i)+"."+domain;
                if(await Indicator(uri))
                {
                    subdomains.Add(i, words.ElementAt(i));
                    sumH ++;
                    estimates.Add(i, (absX/n)*sumH);
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