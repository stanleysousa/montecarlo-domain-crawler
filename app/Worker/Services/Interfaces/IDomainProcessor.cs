using System.Collections.Generic;
using System.Threading.Tasks;

namespace Worker.Services.Interfaces
{
    public interface IDomainProcessor
    {
        Task<(Dictionary<int, double> estimates, Dictionary<int, string> found)> Process();
    }
}