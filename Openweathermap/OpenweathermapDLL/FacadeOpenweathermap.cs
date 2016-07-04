using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using IInfoProxy;
using ReadInformation;

namespace OpenweathermapDLL
{
    public class FacadeOpenweathermap
    {
        private IMainInfoProxy ProxyConfig
        {
            get
            {
                return _answer.ProxyService;
            }
        }
        private readonly IAnswer _answer;
        public FacadeOpenweathermap(IAnswer answer)
        {
            _answer = answer;
        }

        public async Task<WeatherInfo> GetInformation(string town)
        {
            var result = await _answer.InfoAnswerAsync(ProxyConfig.GetProxy(WebRequest.Create(Url(town))));    
            return (new JavaScriptSerializer()).Deserialize<WeatherInfo>(result);
        }


        private static string AppID
        {
            get
            {
                return ConfigurationManager.AppSettings["keyOpenweaher"];
            }
        }

        private static string Url(string town)
        {
           return string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&cnt=1&APPID={1}",town, AppID);
        }
    }
}
