namespace TrainSystem.Models.ModelDatabase
{
    public class WagonConditionModel : BaseModel
    {
        public Guid WagonId { get; set; }
        public Guid ConditionId { get; set; }
    }
}
