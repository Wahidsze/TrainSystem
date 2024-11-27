namespace TrainSystem.Models.ModelDatabase
{
    public class UserModel : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? FamilyName { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }

    }
}
