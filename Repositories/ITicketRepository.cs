using TrainSystem.Models.ModelDatabase;

namespace TrainSystem.Repositories
{
    public interface ITicketRepository
    {
        public List<RouteModel> GetAllRoute();
        public WagonModel GetWagonById(Guid wagonId);
        public PlaceModel GetPlaceById(Guid placeId);
        public UserTicketModel GetUserTicketById(Guid ticketId);
        public List<Condition> GetConditionsById(Guid wagonId);
        public DateModel GetDateById(Guid dateId);
        public RouteModel GetRouteById(Guid routeId);
		public TrainModel GetTrainById(Guid trainId);
		public IQueryable<IGrouping<Guid, WagonInfo>> GroupingPlacesByWagons(List<Guid> TicketsId);
        public IQueryable<IGrouping<TicketInfo, TicketModel>> GroupingTicketsByTrain(DateTime DateStart, String PointStart, String PointEnd);
    }
}
    