using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http;
namespace TrainSystem.Repositories
{
   
    public class TicketHTTPRepository : ITicketHTTPRepository
    {
        private string APIKey { get; set; } = "?apikey=f6fc2eff-e297-4f09-9f62-d89e83ab6fe2";
        private HttpClient _client { get; set; }
        public TicketHTTPRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.rasp.yandex.net/v3.0/stations_list/");
            _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }
        ~TicketHTTPRepository()
        {
            _client.Dispose();
        }

        public async Task<CountriesJson.Root> GetStation()
        {
            string parameters = APIKey+"&lang=ru_RU&format=json";
            HttpResponseMessage response = _client.GetAsync(parameters).Result;
            return await JsonParser<CountriesJson.Root>.GetJsonData(response);
        }
        public async Task<StationsJson.Root> GetRouteByCodeStation(string code)
        {
            string parameters = APIKey + string.Format("&station={0}&transport_types=train",code);
            HttpResponseMessage response = _client.GetAsync(parameters).Result;
            return await JsonParser<StationsJson.Root>.GetJsonData(response);
        }
    }
}
