using TrainSystem.Models.ModelDatabase;
using TrainSystem.Database;

namespace TrainSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IBaseRepository<UserModel> _users {  get; set; }
        public UserRepository(ApplicationContext applicationContext) 
        {
            _users = new BaseRepository<UserModel>(applicationContext);
        }
        public async Task<UserModel> GetUserByEmailAndPassword(String email, String password) 
        {
            return await _users.GetByAttribute(u => u.Email==email && u.Password==password);
        }
        public UserModel CreateUserByEmailAndPassword(String email, String password)
        {
            return _users.Create(new UserModel { Id=Guid.NewGuid(), Email=email, Password=password }); ;
        }
    }
}
