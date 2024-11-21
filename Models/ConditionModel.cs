namespace TrainSystem.Models
{
    public enum Condition
    {
        BioToilet,
        AllowPets,
        Conditioner
    }
    public class ConditionModel : BaseModel
    {
        public Condition ConditionName { get; set; }
    }
}