using System.Security.Claims;
using TrainSystem.Models.ModelViews;

namespace TrainSystem.Services
{
	public interface IUserService
	{
		public Task<ClaimsIdentity?> Login(LoginViewModel login);
		public Task<ClaimsIdentity?> Register(RegisterViewModel login);
	}
}
