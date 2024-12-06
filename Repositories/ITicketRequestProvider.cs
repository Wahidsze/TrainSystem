namespace TrainSystem.Repositories
{
    public interface ITicketRequestProvider
    {
        public Task<CountriesJson.Root> GetStations();
        public Task<StationsJson.Root> GetRoutesByCodeStation(string code);
    }
}
