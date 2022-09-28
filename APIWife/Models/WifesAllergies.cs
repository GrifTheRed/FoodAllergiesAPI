using System;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static APIWife.Models.RootModel;

namespace APIWife.Models
{
    public class WifesAllergies
    {
        public async Task<Root> GetFood()
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

            var body = "";
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
            }
            string recipeTitle = null;
            Root myDeserializedClass = new Root();
            if (!string.IsNullOrEmpty(body))
            {
                
                myDeserializedClass = JsonConvert.DeserializeObject<Root>(body);
                foreach (var Hit in myDeserializedClass.Hits)
                {
                    //Console.WriteLine(Hit.Recipe.Label);
                    recipeTitle = Hit.Recipe.Label;

                }
            }
            return myDeserializedClass;

        }


        }

}





