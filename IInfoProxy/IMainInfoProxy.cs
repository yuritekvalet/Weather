using System.Net;

namespace IInfoProxy
{
    public interface IMainInfoProxy
    {
        WebRequest GetProxy(WebRequest request);

    }
}
