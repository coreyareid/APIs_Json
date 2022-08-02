using System;
using APIs_Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;

var client = new HttpClient();
var quote = new QuoteMaker9000(client);

// Exercise One
bool theTruth = true;
while (theTruth)
{
    Console.WriteLine("Would you like to hear a random Chuck Norris Fact? Yes / No");
    string response = Console.ReadLine().ToString().ToLower();

    if (response == "yes")
    {
        Console.WriteLine($"{quote.NorrisQuote()}");
        Console.WriteLine("\n\nWould You like to hear another Chuck Norris fact? Yes / No");
        response = Console.ReadLine().ToString().ToLower();
        if (response == "yes")
        {
            Console.WriteLine($"{quote.NorrisQuote()}");
        }
        if (response == "no")
        {
            Console.WriteLine("Fine . . . Lets check the weather");
            theTruth = false;
        }
    }
    else if (response == "no")
    {
        Console.WriteLine("You have to say yes or Chuck Norris is going to roundhouse kick you!");
    }
    else
    {
        Console.WriteLine("You didn\'t say yes or no. Try Again!");
    }
}

// Exercise Two
var clientTwo = new HttpClient();
var theWeather = new WeatherAPI(clientTwo);
theWeather.WeatherApp();