using Newtonsoft.Json;
using NLayerProject.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Web.ApiServices
{
    public class PersonApiService
    {
        private readonly HttpClient _httpClient;

        public PersonApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> Login(PersonDto personDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(personDto), Encoding.UTF8, "application/json");

            bool ok = false;

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:57362/api/Person"),
                Content = stringContent,
            };

            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            var success = response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                ok = true;
            }
            else
            {
                ok = false;
            }

            return ok;
        }

        public async Task<PersonDto> Get(string mail)
        {
            var response = await _httpClient.GetAsync($"person/{mail}");

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<PersonDto>(await response.Content.ReadAsStringAsync());
            else
                return null;
        }
    }
}
