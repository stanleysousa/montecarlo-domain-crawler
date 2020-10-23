using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCDomainCrawler.Worker.Services.Interfaces
{
    public interface IDomainProcessor
    {
        (Dictionary<int, double> estimates, Dictionary<int, string> found) Process();
    }
}