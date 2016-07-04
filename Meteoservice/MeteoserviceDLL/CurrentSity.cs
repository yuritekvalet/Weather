using System.Text.RegularExpressions;

namespace MeteoserviceDLL
{
    public class CurrentSity
    {
        private readonly string _data;
        private readonly string _smallImage;
        public CurrentSity(string data,string smallImage)
        {
            _data = data;
            _smallImage = smallImage;
        }

        public string SmallImage
        {
            get
            {
                return _smallImage;
            }
        }
        public string Town
        {
            get
            {
                return new Regex(@"<h1>(?<town>.*)</h1>").Match(_data).Groups["town"].Value;
            }
        }

        public string Osadki
        {
            get
            {
                return new Regex(@"<td class=""title"">Облачность:</td>[^<]*?<td>(?<osadki>[^<]+)</td>").Match(_data).Groups["osadki"].Value;
            }
        }

        public string Wind
        {
            get
            {
                return
                    new Regex(@"<td class=""title"">Ветер:</td>[^<]*?<td>(?<wind>[^<]+)</td>").Match(_data).Groups[
                        "wind"].Value;
            }
        }

        public string PressureAtmosphere
        {
            get
            {
                return new Regex(@"<td class=""title"">Атмосферное давление:</td>[^<]*?<td>(?<PressureAtmosphere>[^<]+)</td>").Match(_data).Groups["PressureAtmosphere"].Value;
            }
        }

        public string Temperature
        {
            get
            {
                return new Regex(@"<td class=""title"">Температура воздуха:</td>[^<]*?<td>(?<Temperature>[^<]+)</td>").Match(_data).Groups["Temperature"].Value;
            }
        }
    }
}
