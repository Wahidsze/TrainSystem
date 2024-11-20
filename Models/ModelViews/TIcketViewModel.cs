namespace TrainSystem.Models.ModelViews
{
    public class TicketViewModel
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public String PointStart { get; set; }
        public String PointEnd { get; set; }
        public String TrainName { get; set; }
        public String TrainType { get; set; }
        public List<WagonViewModel> Wagons { get; set; }
    }
}
