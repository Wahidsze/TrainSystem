using TrainSystem.Repositories;
using TrainSystem.Models;
using TrainSystem.Models.ModelViews;
namespace TrainSystem.Services
{
    public class TicketService : ITicketService
    {
        private IBaseRepository<RouteModel> _routes { get; set; }
        private IBaseRepository<DateModel> _dates { get; set; }
        private IBaseRepository<TicketModel> _tickets { get; set; }
        private IBaseRepository<TrainModel> _trains { get; set; }
        private IBaseRepository<PlaceModel> _places { get; set; }
        public List<RouteModel> GetAllCities() 
        {
            return _routes.GetAll();
        }
        public List<TicketViewModel> GetTicketsByDateAndPath(DateTime DateS,String PointS,String PointE)
        {
            var ticket = from t in _tickets.GetSet()
                         join d in _dates.GetSet() on t.DateId equals d.Id
                         join r in _routes.GetSet() on t.RouteId equals r.Id
                         select new TicketViewModel
                         {
                             TrainId = t.TrainId,
                             PlaceId = t.PlaceId,
                             DateStart = d.DateStart,
                             DateEnd = d.DateEnd,
                             PointStart = r.PointStart,
                             PointEnd = r.PointEnd,
                             Cost = t.Cost
                         };

           
            return ticket.Where((t => t.DateStart == DateS && t.PointStart == PointS && t.PointEnd == PointE)).ToList();
        }
        public TrainModel GetTrainById(Guid TrainId) 
        {
            return _trains.GetById(TrainId);
        }
        public PlaceModel GetPlaceById(Guid PlaceId)
        {
            return _places.GetById(PlaceId);
        }

    }
}
