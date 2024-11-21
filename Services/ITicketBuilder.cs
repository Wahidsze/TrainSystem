using TrainSystem.Models.ModelViews;
namespace TrainSystem.Services
{
    public interface ITicketBuilder
    {
        public TicketViewModel Build();
        public ITicketBuilder SetDate(Guid DateId);
        public ITicketBuilder SetRoute(Guid RouteId);
        public ITicketBuilder SetWagons(List<Guid> PlacesId);
        public ITicketBuilder SetTrain(Guid TrainId);
        
    }
}
