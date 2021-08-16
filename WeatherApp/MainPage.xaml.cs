using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;

namespace WeatherApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Get_Weather(Object sender, EventArgs e)
        {
            using(var client = new HttpClient())
            {
                var jsontxt = await client.GetStringAsync("http://api.openweathermap.org/data/2.5/weather?q=" + city.Text + "&APPID=18445b5e58e14021c2d2294ae7983325");
                var data = Openweatherproxy.FromJson(jsontxt);
                Result.Text = "Station name: " + data.Name +
                    "\nTemperature: " + data.Main.Temp + "°C" +
                    "\n Humidty: "+ data.Main.Humidity +
                    "\nDescription: " + data.Weather[0].Description;
                //string iconurl = "http://openweathermap.org/img/wn/" + data.Weather[0].Icon + ".png";
                // UriImageSource img = new UriImageSource();
                // img.Uri = new Uri(iconurl);
                // IconName.Source = img;

                IconName.Source = ImageSource.FromResource("WeatherApp.Assets.Weather." + data.Weather[0].Icon + ".png" );
                
            }
        }
    
    }
}
