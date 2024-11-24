namespace TrainSystem.Repositories
{
    public interface ITicketHTTPRepository
    {
        public Task<CountriesJson.Root> GetStation();
        public Task<StationsJson.Root> GetRouteByCodeStation(string code);
    }
}
