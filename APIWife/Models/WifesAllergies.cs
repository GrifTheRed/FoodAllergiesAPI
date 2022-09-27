using System;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace APIWife.Models
{
    public class WifesAllergies
    {
        public async void GetActivity()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://edamam-recipe-search.p.rapidapi.com/search?q=chicken"),
                Headers =
    {
        { "X-RapidAPI-Key", "8841bbda21msh16911dfe61c7012p1959fcjsnad06c1ac3c43" },
        { "X-RapidAPI-Host", "edamam-recipe-search.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var bodyObject = JObject.Parse(body);
                Console.WriteLine(bodyObject["results"][0]["title"]);
            }

        }

    }

}
    


