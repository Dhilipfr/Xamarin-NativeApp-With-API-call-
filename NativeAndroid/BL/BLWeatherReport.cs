using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NativeAndroid.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace NativeAndroid.BL
{
    public class BLWeatherReport
    {
        public string Lattitude { get; set; }
        public string Longitude { get; set; }
        public string ApiId { get; } = "0f17ae51a8691b2133462e309cea8db6";
        public string DistrictUrl { get; set; }
        public RootObject WeatherList { get; set; }        
        
        public BLWeatherReport(string lattitude,string longitude)
        {
            this.Lattitude = lattitude;
            this.Longitude = longitude;
            DistrictUrl = string.Format("http://api.openweathermap.org/data/2.5/find?lat={0}&lon={1}&cnt=10&AppId={2}", Lattitude, Longitude, ApiId);
        }
        public async Task GetWeather()
        {            
            var client = new HttpClient();
            var json = await client.GetStringAsync(DistrictUrl);
            WeatherList = JsonConvert.DeserializeObject<RootObject>(json);
        }
    }
}