using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TrainSystem.Models
{
    public class PlaceModel : BaseModel
    {
        public Guid WagonId { get; set; }
        public String PlaceName { get; set; }
    }
}
