namespace TrainSystem.Models.ModelViews
{
    public enum Condition
    {
        BioToilet,
        AllowPets,
        Conditioner

    }
    public class WagonViewModel
    {
        public String WagonName { get; set; }
        public String WagonType { get; set; }
        public List<Condition> WagonConditions { get; set; }
        public List<PlaceViewModel> WagonPlacements { get; set; }
    }
}
