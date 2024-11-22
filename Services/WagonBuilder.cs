using TrainSystem.Models;
using TrainSystem.Models.ModelViews;
using TrainSystem.Repositories;

namespace TrainSystem.Services
{
    public class WagonBuilder : IWagonBuilder
    {
        private WagonViewModel _target { get; set; }
        private TicketRepository _repository { get; set; }
        public WagonBuilder(TicketRepository repository)
        {
            _target = new WagonViewModel();
            _repository = repository;
        }
        public WagonViewModel Build()
        {
            var current = _target;
            _target = new WagonViewModel();
            return current;
        }
        public IWagonBuilder SetNameAndType(Guid WagonId)
        {
            var wagon = _repository.GetWagonById(WagonId);
            _target.WagonName = wagon.WagonName;
            _target.WagonType = wagon.WagonType;
            return this;
        }
        public IWagonBuilder SetPlace(List<PlaceAndTicketId> PlaceAndTicketId)
        {
            List<PlaceViewModel> places = new List<PlaceViewModel>(); 
            foreach(var obj in PlaceAndTicketId)
            {
                String name = _repository.GetPlaceById(obj.PlaceId).PlaceName;
                bool isOccupied = _repository.GetUserTicketById(obj.TicketId) != null;
                places.Add(new PlaceViewModel {PlaceName=name, IsOccupied=isOccupied });
            }
            _target.WagonPlacements = places;
            return this;
        }
        public IWagonBuilder SetConditions(Guid WagonId)
        {
            _target.WagonConditions = _repository.GetConditionsById(WagonId);
            return this;
        }
    }
}
