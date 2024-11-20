using TrainSystem.Models.ModelViews;

namespace TrainSystem.Services
{
    public interface IWagonBuilder
    {
        public WagonViewModel Build();
        public IWagonBuilder SetNameAndType(Guid WagonId);
        public IWagonBuilder SetPlace(List<Guid> PlaceId);
        public IWagonBuilder SetConditions(Guid WagonId);
    }
}
