using System.ComponentModel.DataAnnotations;

namespace TrainSystem.Models.ModelViews
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage="Не указан Email")]
        [EmailAddress(ErrorMessage = "Введите корректный email")]
        public String Email { get; set; }

        [Required(ErrorMessage="Не указан пароль")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Compare("Password", ErrorMessage="Пароль введен неверно")]
        [DataType(DataType.Password)]
        public String ConfirmPassword { get; set; }
    }
}
