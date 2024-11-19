using TrainSystem.Models;

namespace TrainSystem.Repositories
{
	public interface IBaseRepository<DbModel> where DbModel : BaseModel
	{
		public List<DbModel> GetAll();
		public DbModel GetById(Guid id);
		public DbModel Update(DbModel model);
		public void DeleteById(DbModel model);
		public DbModel Create(DbModel model);
	}
}
