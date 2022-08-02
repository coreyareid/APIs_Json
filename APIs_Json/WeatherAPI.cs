using System;
using Newtonsoft.Json.Linq;
namespace APIs_Json
{
    public class WeatherAPI
    {
        private HttpClient _client;
        public WeatherAPI(HttpClient clientTwo)
        {
            _client = clientTwo;
        }

        public void WeatherApp()
        {
            string keyAPI = File.ReadAllText("appsettings.json");
            string key = JObject.Parse(keyAPI).GetValue("weatherKey").ToString();

            Console.WriteLine("\nEnter city name for weather information:");
            var city = Console.ReadLine();

            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q=" +
                $"{city}&appid={key}&units=imperial";
            var response = _client.GetStringAsync(weatherURL).Result;
            double parsing = double.Parse(JObject.Parse(response)["main"]["temp"].ToString());
            double theFeels = double.Parse(JObject.Parse(response)["main"]["feels_like"].ToString());

            Console.WriteLine($"Temperature is: {parsing}");
            Console.WriteLine($"What it feels like: {theFeels}");
        }
    }
}

