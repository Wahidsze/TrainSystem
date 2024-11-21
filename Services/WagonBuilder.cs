using TrainSystem.Models;
using TrainSystem.Models.ModelViews;
using TrainSystem.Repositories;

namespace TrainSystem.Services
{
    public class WagonBuilder : IWagonBuilder
    {
        private WagonViewModel _target { get; set; }
        private IBaseRepository<PlaceModel> _places { get; set; }
        private IBaseRepository<WagonModel> _wagons { get; set; }
        private IBaseRepository<ConditionModel> _conditions { get; set; }
        private IBaseRepository<WagonConditionModel> _wagonConditions { get; set; }
        private IBaseRepository<UserTicketModel> _userTickets { get; set; }
        public WagonBuilder(IBaseRepository<PlaceModel> places, IBaseRepository<WagonModel> wagons,
            IBaseRepository<ConditionModel> conditions, IBaseRepository<WagonConditionModel> wagonConditions,
            IBaseRepository<UserTicketModel> userTicket)
        {
            _places = places;
            _wagons = wagons;
            _conditions = conditions;
            _wagonConditions = wagonConditions;
            _userTickets = userTicket;
            _target = new WagonViewModel();
        }
        public WagonViewModel Build()
        {
            var current = _target;
            _target = new WagonViewModel();
            return current;
        }
        public IWagonBuilder SetNameAndType(Guid WagonId)
        {
            var wagon = _wagons.GetById(WagonId);
            _target.WagonName = wagon.WagonName;
            _target.WagonType = wagon.WagonType;
            return this;
        }
        public IWagonBuilder SetPlace(List<PlaceAndTicketId> PlaceAndTicketId)
        {
            List<PlaceViewModel> places = new List<PlaceViewModel>(); 
            foreach(var obj in PlaceAndTicketId)
            {
                String name = _places.GetById(obj.PlaceId).PlaceName;
                bool isOccupied = _userTickets.GetById(obj.TicketId) != null;
                places.Add(new PlaceViewModel {PlaceName=name, IsOccupied=isOccupied });
            }
            _target.WagonPlacements = places;
            return this;
        }
        public IWagonBuilder SetConditions(Guid WagonId)
        {
            var wagonConditions = _wagonConditions.GetSet()
                .Where(wc => wc.WagonId == WagonId)
                .Join(_conditions.GetSet(), w => w.ConditionId, c => c.Id, (w,c) => c.ConditionName).ToList();
            _target.WagonConditions = wagonConditions;
            return this;
        }
    }
}
