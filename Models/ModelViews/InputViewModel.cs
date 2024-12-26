using System.ComponentModel.DataAnnotations;
namespace TrainSystem.Models.ModelViews
{
    public class InputViewModel
    {
        [Required(ErrorMessage = "Не указано место отправления")]
        public String PointStart { get; set; }
        [Required(ErrorMessage = "Не указано место прибытия")]
        public String PointEnd { get; set; }
        [Required(ErrorMessage = "Не указано дата отправления")]
        public DateTime DateStart { get; set; }
    }
}
