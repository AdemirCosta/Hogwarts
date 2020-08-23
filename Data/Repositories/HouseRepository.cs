using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class HouseRepository: IHouseRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string _houseApiUrl = "https://www.potterapi.com/v1/houses";
        private const string _apiKey = "$2a$10$W/Gn2vWbGQod1MjKsJBvYOixtGVQzAxhA86Zy6B909zxKlpeAz/ou";


        public HouseRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<bool> CheckHouseExistence(string houseId)
        {
            string getHouseUrl = _houseApiUrl + "/" + houseId + "?key=" + _apiKey;

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, getHouseUrl);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var house = await JsonSerializer.DeserializeAsync<IEnumerable<House>>(responseStream);

                return house.FirstOrDefault()?._id == houseId;
            }
            else
            {
                throw new HttpRequestException("It was not possible to check house existence");
            }
        }
    }
}
