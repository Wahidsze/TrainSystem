using TrainSystem.Models.ModelViews;
using TrainSystem.Repositories;

namespace TrainSystem.Services
{
    public class TicketBuilder : ITicketBuilder
    {
        private TicketViewModel _target { get; set; }
        private IWagonBuilder _builder { get; set; }
        private TicketRepository _repository { get; set; }
        public TicketBuilder(TicketRepository repository)
        {
            _target = new TicketViewModel();
            _repository = repository;
            _builder = new WagonBuilder(_repository);
        }
        public TicketViewModel Build()
        {
            var current = _target;
            _target = new TicketViewModel();
            return current;
        }
        public ITicketBuilder SetDate(Guid DateId)
        {
            var date = _repository.GetDateById(DateId);
            _target.DateStart = date.DateStart; 
            _target.DateEnd = date.DateEnd;
            return this;
        }
        public ITicketBuilder SetRoute(Guid RouteId)
        {
            var route = _repository.GetRouteById(RouteId);
            _target.PointStart = route.PointStart;
            _target.PointEnd = route.PointEnd;
            return this;
        }
        public ITicketBuilder SetWagons(List<Guid> TicketsId)
        {
            var wagons = _repository.GroupingPlacesByWagons(TicketsId);
            List<WagonViewModel> result = new List<WagonViewModel>();
            foreach (var wagon in wagons)
            {
                result.Append(_builder
                    .SetNameAndType(wagon.Key)
                    .SetPlace(wagon.Select(w => new PlaceAndTicketId {TicketId=w.TicketId, PlaceId=w.PlaceId}).ToList())
                    .SetConditions(wagon.Key)
                    .Build());
            }
            _target.Wagons = result;
            return this;
        }
        public ITicketBuilder SetTrain(Guid TrainId)
        {
            var train = _repository.GetTrainById(TrainId);
            _target.TrainName = train.TrainName;
            _target.TrainType = train.TrainType;
            return this;
        }
    }
}
