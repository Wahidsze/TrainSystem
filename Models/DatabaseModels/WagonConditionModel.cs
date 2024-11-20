namespace TrainSystem.Models
{
    public class WagonConditionModel : BaseModel
    {
        public Guid WagonId { get; set; }
        public Guid ConditionId { get; set; }
    }
}
