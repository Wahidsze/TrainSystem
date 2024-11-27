using System.Text.Json.Serialization;

namespace TrainSystem.Repositories.StationsJson
{
    public class Pagination
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }
    }

    public class Station
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("station_type")]
        public string StationType { get; set; }

        [JsonPropertyName("popular_title")]
        public string PopularTitle { get; set; }

        [JsonPropertyName("short_title")]
        public string ShortTitle { get; set; }

        [JsonPropertyName("transport_type")]
        public string TransportType { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class Codes
    {
        [JsonPropertyName("icao")]
        public string Icao { get; set; }

        [JsonPropertyName("sirena")]
        public string Sirena { get; set; }

        [JsonPropertyName("iata")]
        public string Iata { get; set; }
    }

    public class Carrier
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("codes")]
        public Codes Codes { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public class TransportSubtype
    {
        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public class Thread
    {
        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("short_title")]
        public string ShortTitle { get; set; }

        [JsonPropertyName("carrier")]
        public Carrier Carrier { get; set; }

        [JsonPropertyName("transport_type")]
        public string TransportType { get; set; }

        [JsonPropertyName("vehicle")]
        public string Vehicle { get; set; }

        [JsonPropertyName("transport_subtype")]
        public TransportSubtype TransportSubtype { get; set; }

        [JsonPropertyName("express_type")]
        public string ExpressType { get; set; }
    }

    public class Schedule
    {
        [JsonPropertyName("except_days")]
        public string ExceptDays { get; set; }

        [JsonPropertyName("arrival")]
        public DateTime Arrival { get; set; }

        [JsonPropertyName("thread")]
        public Thread Thread { get; set; }

        [JsonPropertyName("is_fuzzy")]
        public bool IsFuzzy { get; set; }

        [JsonPropertyName("days")]
        public string Days { get; set; }

        [JsonPropertyName("stops")]
        public string Stops { get; set; }

        [JsonPropertyName("departure")]
        public DateTime Departure { get; set; }

        [JsonPropertyName("terminal")]
        public string Terminal { get; set; }

        [JsonPropertyName("platform")]
        public string Platform { get; set; }
    }

    public class Interval
    {
        [JsonPropertyName("density")]
        public string Density { get; set; }

        [JsonPropertyName("end_time")]
        public DateTime EndTime { get; set; }

        [JsonPropertyName("begin_time")]
        public DateTime BeginTime { get; set; }
    }

    public class IntervalSchedule
    {
        [JsonPropertyName("except_days")]
        public string ExceptDays { get; set; }

        [JsonPropertyName("thread")]
        public Thread Thread { get; set; }

        [JsonPropertyName("is_fuzzy")]
        public bool IsFuzzy { get; set; }

        [JsonPropertyName("days")]
        public string Days { get; set; }

        [JsonPropertyName("stops")]
        public string Stops { get; set; }

        [JsonPropertyName("terminal")]
        public string Terminal { get; set; }

        [JsonPropertyName("platform")]
        public string Platform { get; set; }
    }

    public class ScheduleDirection
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public class Direction
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }

        [JsonPropertyName("station")]
        public Station Station { get; set; }

        [JsonPropertyName("schedule")]
        public List<Schedule> Schedule { get; set; }

        [JsonPropertyName("interval_schedule")]
        public List<IntervalSchedule> IntervalSchedule { get; set; }

        [JsonPropertyName("schedule_direction")]
        public ScheduleDirection ScheduleDirection { get; set; }

        [JsonPropertyName("directions")]
        public List<Direction> Directions { get; set; }
    }
}
