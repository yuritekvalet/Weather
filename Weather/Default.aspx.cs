using System;
using System.Web;
using System.Web.UI;
using MeteoserviceDLL;
using OpenweathermapDLL;
using ReadInformation;


namespace Weather
{
    public partial class Default : Page
    {
        private static bool _firstLoad;
        private const string NameCookies = "myCookie";
        private const string DefaultInputString = "Укажите город";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!_firstLoad)
            {
                txtCity.Text = Request.Cookies[NameCookies] != null ? Request.Cookies[NameCookies].Value : DefaultInputString;
                _firstLoad = true;
            }
        }

        protected void GetWeatherInfo(object sender, EventArgs e)
        {
            var userInput = txtCity.Text.Trim().ToLower();
            Response.Cookies.Clear();
            if (userInput == DefaultInputString.ToLower()) return;
            var cookie = new HttpCookie(NameCookies)
            {
                Value = userInput,
                Expires = DateTime.Now.Add(TimeSpan.FromHours(200))
            };

            Response.Cookies.Add(cookie);

            System.Threading.Tasks.Parallel.Invoke(() => InfoMeteoservice(userInput),() => InfoOpenweather(userInput) );

        }

        public async void InfoOpenweather(string userInput)
        {
        
            var facade = new FacadeOpenweathermap(new Answer());
            var weatherInfo = await facade.GetInformation(userInput);
            ViewOpenweathermapAsync(weatherInfo);
        }

        public async void InfoMeteoservice(string userInput)
        {
            var facade = new FacadeMeteoservice(new Answer());
            var weatherInfo2 = await facade.GetInformation(userInput);
            ViewMeteoserviceAsync(weatherInfo2);
        }
        void ViewOpenweathermapAsync(WeatherInfo weatherInfo)
        {
            lblCity_Country.Text = weatherInfo.City.Name + "," + weatherInfo.City.Country;
            imgCountryFlag.ImageUrl = string.Format("http://openweathermap.org/images/flags/{0}.png", weatherInfo.City.Country.ToLower());
            lblDescription.Text = weatherInfo.List[0].Weather[0].Description;
            imgWeatherOpenweatherIcon.ImageUrl = string.Format("http://openweathermap.org/img/w/{0}.png", weatherInfo.List[0].Weather[0].Icon);
            lblTempMin.Text = string.Format("{0}°С", Math.Round(weatherInfo.List[0].Temp.Min, 1));
            lblTempMax.Text = string.Format("{0}°С", Math.Round(weatherInfo.List[0].Temp.Max, 1));
            lblTempDay.Text = string.Format("{0}°С", Math.Round(weatherInfo.List[0].Temp.Day, 1));
            lblTempNight.Text = string.Format("{0}°С", Math.Round(weatherInfo.List[0].Temp.Night, 1));
            lblHumidity.Text = weatherInfo.List[0].Humidity.ToString();
            tblWeather.Visible = true;
        }

         void ViewMeteoserviceAsync(CurrentSity weatherInfo)
        {
           

            imgWeatherMeteoserviceIcon.ImageUrl = weatherInfo.SmallImage;
            lblMeteoOsadki.Text = weatherInfo.Osadki;
            lblMeteoWind.Text = weatherInfo.Wind;
            lblMeteoTemperature.Text = weatherInfo.Temperature;
            lblMeteoTown.Text = weatherInfo.Town;
            tblWeather2.Visible = true;
        }
    }
}