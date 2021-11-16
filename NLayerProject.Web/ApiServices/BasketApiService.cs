using Newtonsoft.Json;
using NLayerProject.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NLayerProject.Web.ApiServices
{
    public class BasketApiService
    {
        private readonly HttpClient _httpClient;

        public BasketApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<BasketDtoSpecific>> GetAllByPidAsync(int pid)
        {
            IEnumerable<BasketDtoSpecific> baskettDtos;

            var response = await _httpClient.GetAsync($"basket/{pid}");

            if (response.IsSuccessStatusCode)
            {
                baskettDtos =
                    JsonConvert.DeserializeObject<IEnumerable<BasketDtoSpecific>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                baskettDtos = null;
            }

            return baskettDtos;
        }
        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"basket/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
