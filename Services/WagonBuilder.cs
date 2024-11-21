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
        public WagonBuilder()
        {
            _target = new WagonViewModel();
        }
        public WagonViewModel Build()
        {
            var current = _target;
            _target = new WagonViewModel();
            return _target;
        }
        public IWagonBuilder SetNameAndType(Guid WagonId)
        {

            return this;
        }
        public IWagonBuilder SetPlace(List<Guid> PlaceId)
        {
            return this;
        }
        public IWagonBuilder SetConditions(Guid WagonId)
        {
            return this;
        }
    }
}
