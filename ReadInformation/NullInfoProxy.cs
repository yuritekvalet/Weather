using System.Net;
using IInfoProxy;

namespace ReadInformation
{
    public class NullInfoProxy : IMainInfoProxy
    {
        public WebRequest GetProxy(WebRequest request)
        {
            return request;
        }
    }
}
