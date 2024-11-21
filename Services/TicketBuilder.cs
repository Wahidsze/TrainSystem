using System.Text.RegularExpressions;
using TrainSystem.Models;
using TrainSystem.Models.ModelViews;
using TrainSystem.Repositories;

namespace TrainSystem.Services
{
    public class TicketBuilder : ITicketBuilder
    {
        private TicketViewModel _target { get; set; }
        private IWagonBuilder _builder { get; set; }
        private IBaseRepository<TrainModel> _trains { get; set; }
        private IBaseRepository<PlaceModel> _places { get; set; }
        private IBaseRepository<WagonModel> _wagons { get; set; }
        private IBaseRepository<DateModel> _dates{ get; set; }
        private IBaseRepository<RouteModel> _routes { get; set; }
        private IBaseRepository<TicketModel> _tickets { get; set; }
        public TicketBuilder()
        {
            _target = new TicketViewModel();
            //_builder = new WagonBuilder();
        }
        public TicketViewModel Build()
        {
            var current = _target;
            _target = new TicketViewModel();
            return current;
        }
        public ITicketBuilder SetDate(Guid DateId)
        {
            var date = _dates.GetById(DateId);
            _target.DateStart = date.DateStart; 
            _target.DateEnd = date.DateEnd;
            return this;
        }
        public ITicketBuilder SetRoute(Guid RouteId)
        {
            var route = _routes.GetById(RouteId);
            _target.PointStart = route.PointStart;
            _target.PointEnd = route.PointEnd;
            return this;
        }
        public ITicketBuilder SetWagons(List<Guid> TicketsId)
        {
            var tickets = _tickets.GetSet()
                .Where(t => TicketsId.Contains(t.Id))
                .Join(_places.GetSet(), t => t.PlaceId, p => p.Id, (t, p) => new {t.Id, t.PlaceId, p.WagonId});
            var wagons = tickets.GroupBy(t => t.WagonId);
            List<WagonViewModel> result = new List<WagonViewModel>();
            foreach (var wagon in wagons)
            {
                result.Append(_builder
                    .SetNameAndType(wagon.Key)
                    .SetPlace(wagon.Select(w => new PlaceAndTicketId {TicketId=w.Id, PlaceId=w.PlaceId}).ToList())
                    .SetConditions(wagon.Key)
                    .Build());
            }
            _target.Wagons = result;
            return this;
        }
        public ITicketBuilder SetTrain(Guid TrainId)
        {
            var train = _trains.GetById(TrainId);
            _target.TrainName = train.TrainName;
            _target.TrainType = train.TrainType;
            return this;
        }
    }
}
