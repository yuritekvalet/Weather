using System.Net;
using System.Threading.Tasks;
using IInfoProxy;

namespace ReadInformation
{
    public interface IAnswer
    {
        Task<string> InfoAnswerAsync(WebRequest request);
        string InfoAnswer(WebRequest request);
        IMainInfoProxy ProxyService { get; }
    }
}
