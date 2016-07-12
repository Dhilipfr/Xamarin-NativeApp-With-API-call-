using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using NativeAndroid.BL;
using System.Linq;

namespace NativeAndroid
{
    [Activity(Label = "NativeAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {                      
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            ListView list = FindViewById<ListView>(Resource.Id.listView1);

            button.Click += async delegate {
                button.Enabled = false;

                BLWeatherReport weatherReport = new BLWeatherReport("10.80289", "78.698753");

                await weatherReport.GetWeather();

                list.Adapter = new ArrayAdapter<string>(this
                    , Android.Resource.Layout.SimpleListItem1
                    , Android.Resource.Id.Text1
                    , weatherReport.WeatherList.list.Select(s => "Area:" + s.name + " - Humidity:" + s.main.humidity + ", Temp:" + s.main.temp_max).ToArray());

                button.Enabled = true;
            };
        }
    }
}

