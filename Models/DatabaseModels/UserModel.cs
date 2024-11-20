namespace TrainSystem.Models
{
    public class UserModel : BaseModel
    {
        public String Email { get; set; }
        public String Password { get; set; }
        public String FamilyName {get; set;}
        public String Surname { get; set;}
        public String Name { get; set;}

    }
}
