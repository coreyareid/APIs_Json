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
            var key = "cdf930396eb2cfe3b3756e87cc541178";

            Console.WriteLine("\nEnter city name for weather information:");
            var city = Console.ReadLine();

            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q=" +
                $"{city}&appid={key}&units=imperial";
            var response = _client.GetStringAsync(weatherURL).Result;
            var parsing = JObject.Parse(response).GetValue("main").ToString();

            Console.WriteLine(parsing.Replace("{", "").Replace("}", ""));
        }
    }
}

