using System.Net;
using System.Threading.Tasks;
using IInfoProxy;
using ReadInformation;


namespace MeteoserviceDLL
{
    public class FacadeMeteoservice
    {
        private IMainInfoProxy ProxyConfig
        {
            get
            {
                return _answer.ProxyService;
            }
        }
        private readonly IAnswer _answer;
        public FacadeMeteoservice(IAnswer answer)
        {
            _answer = answer;
        }

        public async Task<CurrentSity> GetInformation(string town)
        {
            var allSityInformation = await _answer.InfoAnswerAsync(ProxyConfig.GetProxy(WebRequest.Create(Meteoservice.MainPage)));        
            var currentSity2=new Meteoservice(allSityInformation);
            var likns = currentSity2.GetCurrentSity(town);

            var currentSity=currentSity2.CurrentSityUri(likns.Link);
            var sityInformation=await _answer.InfoAnswerAsync(ProxyConfig.GetProxy(WebRequest.Create(currentSity)));
            return new CurrentSity(sityInformation,Meteoservice.MainPage+likns.Img);

        }
    }
}
