using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TrainSystem.Database;
using TrainSystem.Models.ModelDatabase;
using TrainSystem.Models.ModelViews;
using TrainSystem.Repositories;

namespace TrainSystem.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _users { get; set; }
        public UserService(ApplicationContext context) 
        {
            _users = new UserRepository(context);
        }
        public async Task<ClaimsIdentity?> Login(LoginViewModel login)
        {
            var user = await _users.GetUserByEmailAndPassword(login.Email, login.Password);
            if (user != null) 
            {
                return CreateClaimsIndentity(user);
            }
            return null;
        }
        public async Task<ClaimsIdentity?> Register(RegisterViewModel login)
        {
            var user = await _users.GetUserByEmailAndPassword(login.Email, login.Password);
            if(user == null)
            {
                user = _users.CreateUserByEmailAndPassword(login.Email, login.Password);
                return CreateClaimsIndentity(user);
            }
            return null;
        }
        private ClaimsIdentity CreateClaimsIndentity(UserModel user)
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
            };
            return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
