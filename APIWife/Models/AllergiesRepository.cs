using System;
using System.Data;
using Newtonsoft.Json;

namespace APIWife.Models
{
    public class AllergiesRepository 
    {
        private readonly IDbConnection _conn;


        public AllergiesRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<WifesAllergies> GetAllergies()
        {
            var client = new HttpClient();
            var url = "https://rapidapi.com/edamam/api/recipe-search-and-diet";
            var response = client.GetStringAsync(url).Result;

            return View(JsonConvert.DeserializeObject<Root>(response));
        }

        public IEnumerable<WifesAllergies> View(Root? root)
        {
            throw new NotImplementedException();
        }
    }
}

