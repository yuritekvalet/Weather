using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace MeteoserviceDLL
{
    public class Meteoservice
    {
        public static string MainPage
        {
            get
            {
                return "http://www.meteoservice.ru/";
            }
        }

        public string CurrentSityUri(string url)
        {
            if (url.Any())
                return "http://www.meteoservice.ru/weather/now/" + url;
            return "http://www.meteoservice.ru/weather/now/moskva.html";
        }

        private readonly string _mainData;
        public Meteoservice(string data)
        {
            _mainData = data;
            _listSity = new List<SityMeteoservice>();
        }


        private HtmlDocument HTMLDocument
        {
            get
            {
               var document = new HtmlDocument();
               document.LoadHtml(_mainData);
               return document;
            }
        }

        private List<SityMeteoservice> _listSity;
        public List<SityMeteoservice> GetAllSity
        {
            get
            {
                if (_listSity.Any())
                    return _listSity;
                _listSity = ReturnTableContent;
                return _listSity;
            }
        }

        public SityMeteoservice GetCurrentSity(string sity)
        {
            if (sity.Any())
                return GetAllSity.SingleOrDefault(ws => ws.SityName.Contains(sity));
            return new SityMeteoservice();
        }

        private List<SityMeteoservice> ReturnTableContent
        {
            get
            {
              return HTMLDocument.DocumentNode.SelectNodes("//ul[@class='city-list']/li").Select(link => new SityMeteoservice
              {
                 Img = link.InnerHtml,
                 SityName = link.InnerText,
                 Link = link.InnerHtml
               }).ToList();
            }
        }
    }
}
