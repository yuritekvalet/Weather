using System.Threading.Tasks;
using IInfoProxy;

namespace MyRequests
{
    public interface IMyRequest
    {
        Task<string> Answer(IMainInfoProxy proxy);
    }
}
