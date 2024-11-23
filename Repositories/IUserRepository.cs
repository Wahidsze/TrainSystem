using Microsoft.EntityFrameworkCore.ChangeTracking;
using TrainSystem.Models.ModelDatabase;

namespace TrainSystem.Repositories
{
    public interface IUserRepository
    {
        public Task<UserModel> GetUserByEmailAndPassword(String email, String password);
        public UserModel CreateUserByEmailAndPassword(String email, String password);
    }
}
