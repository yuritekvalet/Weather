using System.Linq;
using System.Text.RegularExpressions;

namespace MeteoserviceDLL
{
    public class SityMeteoservice
    {
        private string _link;

        public string Link
        {
            get
            {
                return _link;
            }
            set
            {
                var result = Regex.Match(value, "href\\s*=\\s*(?:[\"'](?<1>" + "[^\"']*)[\"']|(?<1>\\S+))");
                if (result.Success)
                {
                    var rowSplit = result.ToString().Split('/');
                    if (rowSplit.Count() > 2)
                    {
                        var contains = rowSplit.SingleOrDefault(ws => ws.Contains(".html"));
                        if (contains != null) _link = Regex.Replace(contains, @"([^a-zA-Z\.])", string.Empty);
                    }
                }

            }

        }
        private string _sityName;
        public string SityName
        {
            get
            {
                return _sityName;
            }
            set
            {
                if (value != null)
                    _sityName = Regex.Replace(value, @"([^a-zA-ZА-Яа-я\-])", string.Empty).Trim().ToLower();

            }

        }
        private string _img;
        public string Img
        {
            get
            {
                return _img;
            }
            set
            {
                var result = Regex.Match(value, @"(?<=<img .*?src\s*=\s*"")[^""]+(?="".*?>)");
                if (result.Success)
                    _img = result.ToString();
            }
        }
    }
}
