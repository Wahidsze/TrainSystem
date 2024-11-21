using TrainSystem.Models.ModelViews;

namespace TrainSystem.Services
{
    public struct PlaceAndTicketId
    {
        public Guid PlaceId { get; set; }
        public Guid TicketId { get; set; }
    }
    public interface IWagonBuilder
    {
        public WagonViewModel Build();
        public IWagonBuilder SetNameAndType(Guid WagonId);
        public IWagonBuilder SetPlace(List<PlaceAndTicketId> TicketId);
        public IWagonBuilder SetConditions(Guid WagonId);
    }
}
