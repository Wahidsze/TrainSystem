namespace TrainSystem.Models.ModelViews
{
    public class WagonViewModel
    {
        public String WagonType { get; set; }
        public List<String> WagonConditions { get; set; }
        public List<PlaceViewModel> WagonPlaces { get; set; }
    }
}
