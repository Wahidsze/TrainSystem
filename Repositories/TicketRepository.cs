using System.Reflection;
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
	public class TicketInfo
	{
		public Guid TrainId { get; set; }
		public Guid DateId { get; set; }
		public Guid RouteId { get; set; }
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
		public List<RouteModel> GetAllRoute()
        {
            return _routes.GetAll();
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
            var result = _wagonConditions
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
		public TrainModel GetTrainById(Guid trainId)
		{
			return _trains.GetById(trainId);
		}
		public IQueryable<IGrouping<Guid, WagonInfo>> GroupingPlacesByWagons(List<Guid> TicketsId)
        {
            var tickets = _tickets
                .Where(t => TicketsId.Contains(t.Id))
                .Join(_places.GetSet(), t => t.PlaceId, p => p.Id, (t, p) => new WagonInfo {TicketId=t.Id, PlaceId=t.PlaceId, WagonId=p.WagonId});
            return tickets.GroupBy(t => t.WagonId);
        }
        public IQueryable<IGrouping<TicketInfo, TicketModel>> GroupingTicketsByTrain(DateTime DateStart, String PointStart, String PointEnd)
        {
			var route = _routes.Where(r => r.PointStart == PointStart && r.PointEnd == PointEnd);
			var dates = _dates.Where(d => d.DateStart == DateStart);
            var tickets = _tickets
                .Where(t => route.Any(r => r.Id == t.RouteId) && dates.Any(d => d.Id == t.DateId))
                .GroupBy(t => new TicketInfo {TrainId=t.TrainId, DateId=t.DateId, RouteId=t.RouteId});
            return tickets;
		}
	}
}
