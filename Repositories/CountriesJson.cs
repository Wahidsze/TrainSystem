using System.Text.Json.Serialization;
using System.Text.Json;

namespace TrainSystem.Repositories.CountriesJson
{
    public class Station
    {
        [JsonPropertyName("direction")]
        public string? Direction { get; set; }

        [JsonPropertyName("codes")]
        public Codes? Codes { get; set; }

        [JsonPropertyName("station_type")]
        public string? StationType { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("longitude")]
        public JsonElement Longitude { get; set; }

        [JsonPropertyName("transport_type")]
        public string? TransportType { get; set; }

        [JsonPropertyName("latitude")]
        public JsonElement Latitude { get; set; }
    }

    public class Settlement
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("codes")]
        public Codes? Codes { get; set; }

        [JsonPropertyName("stations")]
        public List<Station>? Stations { get; set; }
    }

    public class Region
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("codes")]
        public Codes? Codes { get; set; }

        [JsonPropertyName("settlements")]
        public List<Settlement>? Settlements { get; set; }
    }

    public class Country
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("codes")]
        public Codes? Codes { get; set; }

        [JsonPropertyName("regions")]
        public List<Region>? Regions { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("countries")]
        public List<Country>? Countries { get; set; }
    }

    public class Codes
    {
        [JsonPropertyName("yandex_code")]
        public string? YandexCode { get; set; }

        [JsonPropertyName("esr_code")]
        public string? EsrCode { get; set; }
    }

}
