using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TrainSystem.Models.ModelDatabase
{
    public class PlaceModel : BaseModel
    {
        public Guid WagonId { get; set; }
        public string PlaceName { get; set; }
    }
}
