using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
namespace APIs_Json
{
    public class QuoteMaker9000
    {
        private HttpClient _client;
        public QuoteMaker9000(HttpClient client)
        {
            _client = client;
        }

        // Called Method for exercise One
        public string NorrisQuote()
        {
            var chuckQuote = "https://api.chucknorris.io/jokes/random";
            var norrisKick = _client.GetStringAsync(chuckQuote).Result;
            var chuckSays = JObject.Parse(norrisKick).GetValue("value").ToString();
            return chuckSays;
        }
    }
}