using TrainSystem.Models.ModelDatabase;

namespace TrainSystem.Repositories
{
    public interface ITicketRepository
    {
        public WagonModel GetWagonById(Guid wagonId);
        public PlaceModel GetPlaceById(Guid placeId);
        public UserTicketModel GetUserTicketById(Guid ticketId);
        public List<Condition> GetConditionsById(Guid wagonId);
        public DateModel GetDateById(Guid dateId);
        public RouteModel GetRouteById(Guid routeId);
        public IQueryable<IGrouping<Guid, WagonInfo>> GroupingPlacesByWagons(List<Guid> TicketsId);
        public TrainModel GetTrainById(Guid trainId);
    }
}
