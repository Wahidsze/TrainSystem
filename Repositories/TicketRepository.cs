using TrainSystem.Database;
using TrainSystem.Models.ModelDatabase;

namespace TrainSystem.Repositories
{
    public class WagonInfo
    {
        public Guid TicketId { get; set; }
        public Guid PlaceId { get; set; }
        public Guid WagonId { get; set; }
    }
    public class TicketRepository : ITicketRepository
    {
        private IBaseRepository<PlaceModel> _places { get; set; }
        private IBaseRepository<WagonModel> _wagons { get; set; }
        private IBaseRepository<ConditionModel> _conditions { get; set; }
        private IBaseRepository<WagonConditionModel> _wagonConditions { get; set; }
        private IBaseRepository<UserTicketModel> _userTickets { get; set; }
        private IBaseRepository<DateModel> _dates { get; set; }
        private IBaseRepository<RouteModel> _routes { get; set; }
        private IBaseRepository<TicketModel> _tickets { get; set; }
        private IBaseRepository<TrainModel> _trains { get; set; }
        public TicketRepository(ApplicationContext context)
        {
            _places = new BaseRepository<PlaceModel>(context);
            _wagons = new BaseRepository<WagonModel>(context);
            _userTickets = new BaseRepository<UserTicketModel>(context);
            _conditions = new BaseRepository<ConditionModel>(context);
            _wagonConditions = new BaseRepository<WagonConditionModel>(context);
            _dates = new BaseRepository<DateModel>(context);
            _tickets = new BaseRepository<TicketModel>(context);
            _trains = new BaseRepository<TrainModel>(context);
            _routes = new BaseRepository<RouteModel>(context);
        }
        public WagonModel GetWagonById(Guid wagonId)
        {
            return _wagons.GetById(wagonId);
        }
        public PlaceModel GetPlaceById(Guid placeId)
        {
            return _places.GetById(placeId);
        }
        public UserTicketModel GetUserTicketById(Guid ticketId)
        {
            return _userTickets.GetById(ticketId);
        }
        public List<Condition> GetConditionsById(Guid wagonId)
        {
            var result = _wagonConditions.GetSet()
                .Where(wc => wc.WagonId == wagonId)
                .Join(_conditions.GetSet(), w => w.ConditionId, c => c.Id, (w, c) => c.ConditionName).ToList();
            return result;
        }
        public DateModel GetDateById(Guid dateId)
        {
            return _dates.GetById(dateId);
        }
        public RouteModel GetRouteById(Guid routeId)
        {
            return _routes.GetById(routeId);
        }
        public IQueryable<IGrouping<Guid, WagonInfo>> GroupingPlacesByWagons(List<Guid> TicketsId)
        {
            var tickets = _tickets.GetSet()
                .Where(t => TicketsId.Contains(t.Id))
                .Join(_places.GetSet(), t => t.PlaceId, p => p.Id, (t, p) => new WagonInfo
                { 
                    TicketId = t.Id, 
                    PlaceId=t.PlaceId, 
                    WagonId=p.WagonId 
                });
            return tickets.GroupBy(t => t.WagonId);
        }
        public TrainModel GetTrainById(Guid trainId)
        {
            return _trains.GetById(trainId);
        }
    }
}
