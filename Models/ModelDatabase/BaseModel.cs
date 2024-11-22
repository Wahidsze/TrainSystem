using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TrainSystem.Models.ModelDatabase
{
    [PrimaryKey(nameof(Id))]
    public class BaseModel
    {
        public Guid Id { get; set; }
    }
}
