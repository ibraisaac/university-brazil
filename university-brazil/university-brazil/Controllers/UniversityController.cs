using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using university_brazil.Models;

namespace university_brazil.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UniversityController : Controller
    {
        private HttpClient client;
        private Uri uri;
        private List<UniversityModel> universityModels = null;

        public UniversityController()
        {
            universityModels = new List<UniversityModel>();
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://universities.hipolabs.com/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }

            InitializeApi();
        }

        private async void InitializeApi()
        {
            HttpResponseMessage response = client.GetAsync("search?country=brazil").Result;

            if (response.IsSuccessStatusCode)
            {
                uri = response.Headers.Location;

                universityModels = await JsonSerializer.DeserializeAsync<List<UniversityModel>>(await response.Content.ReadAsStreamAsync());
            }
        }

        [HttpGet]
        public IEnumerable<UniversityModel> Get()
        {
            if (universityModels.Count == 0)
            {
                InitializeApi();
            }

            return universityModels.ToList();
        }
    }
}
