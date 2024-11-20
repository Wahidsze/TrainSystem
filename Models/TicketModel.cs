namespace TrainSystem.Models
{
	public class TicketModel : BaseModel
	{
		public Guid RouteId { get; set; }
		public Guid DateId { get; set; }
		public Guid TrainId { get; set; }
		public Guid PlaceId { get; set; }
        public float Cost { get; set; }
    }
}
