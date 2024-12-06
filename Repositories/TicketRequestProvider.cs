using System.Net.Http.Headers;
using System.Text.Json;

namespace TrainSystem.Repositories
{
	public class JsonParser<T>
	{
		public static async Task<T> GetJsonData(HttpResponseMessage response)
		{
			string json = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<T>(json);
		}
	}
	public class TicketRequestProvider : ITicketRequestProvider
    {
        private string _apiKey { get; set; } = "f6fc2eff-e297-4f09-9f62-d89e83ab6fe2";
        private HttpClient _client { get; set; }
        public TicketRequestProvider(string apiKey)
        {
            _apiKey = apiKey;
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.rasp.yandex.net/v3.0/stations_list/");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        ~TicketRequestProvider() => _client.Dispose();
        public async Task<CountriesJson.Root> GetStations()
        {
            string parameters = string.Format("?apikey={0}&lang=ru_RU&format=json", _apiKey);
            HttpResponseMessage response = _client.GetAsync(parameters).Result;
            return await JsonParser<CountriesJson.Root>.GetJsonData(response);
        }
        public async Task<StationsJson.Root> GetRoutesByCodeStation(string code)
        {
            string parameters = string.Format("?apikey={0}&station={1}&lang=ru_RU&format=json&transport_types=train&event=departure", _apiKey, code);
            HttpResponseMessage response = _client.GetAsync(parameters).Result;
            return await JsonParser<StationsJson.Root>.GetJsonData(response);
        }
    }
}
