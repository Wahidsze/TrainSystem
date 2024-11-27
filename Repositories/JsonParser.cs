using System.Text.Json.Serialization;
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
}
