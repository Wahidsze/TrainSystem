namespace TrainSystem.Models.ModelViews
{
    public class TicketViewModel
    {
        public Guid TrainId { get; set; }
        public Guid PlaceId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public String PointStart { get; set; }
        public String PointEnd { get; set; }
        public float Cost { get; set; }

    }
}
