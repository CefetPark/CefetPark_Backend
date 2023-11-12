using CefetPark.Utils.Interfaces.External_Apis;
using CefetPark.Utils.Interfaces.Models;
using CefetPark.Utils.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Utils.External_Apis
{
    public class GoogleGeoApi : IGoogleGeoApi, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        public GoogleGeoApi()
        {
            _httpClient = new HttpClient();
            _apiKey = "AIzaSyCHgKH-eygqNT50LdgzEuT6ssaTkDq9y80";
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<ObterCep?> ObterEnderecoPorCepAsync(string cep)
        {
            var response = await _httpClient.GetAsync($"https://maps.googleapis.com/maps/api/geocode/json?components=postal_code:{cep}&key={_apiKey}");

            ObterCepResponse result;
                if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<ObterCepResponse>(responseBody);

            if (result == null) return null;
            if (!result.results.Any()) return null;
            return result.results.ElementAt(0);
        }
    }
}
