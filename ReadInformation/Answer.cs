using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IInfoProxy;

namespace ReadInformation
{
    public class Answer : IAnswer
    {
        public  async Task<string> InfoAnswerAsync(WebRequest request)
        {
            using (var response = await request.GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                    if (stream != null)
                        using (var reader = new StreamReader(stream))
                        {
                            return await reader.ReadToEndAsync();
                        }
            }
            return "";
        }
        private  IMainInfoProxy _proxyService;
        public  IMainInfoProxy ProxyService
        {
            get
            {
                if (_proxyService != null) return _proxyService;
                var proxyService = ConfigurationManager.AppSettings["ProxyService"];
                if (proxyService != null)
                {
                    if (proxyService.Any())
                    {
                        _proxyService = proxyService == "true" ? (IMainInfoProxy) new InfoProxy() : new NullInfoProxy();
                        return _proxyService;
                    }
                }
                return new NullInfoProxy();
            }
        }
        public  string InfoAnswer(WebRequest request)
        {
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                    if (stream != null)
                        using (var reader = new StreamReader(stream))
                        {
                            return  reader.ReadToEnd();
                        }
            }
            return "";
        }
    }
}
