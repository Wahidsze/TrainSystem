using TrainSystem.Models;
using TrainSystem.Database;

namespace TrainSystem.Repositories
{
	public class BaseRepository<DbModel> : IBaseRepository<DbModel> where DbModel : BaseModel
	{
		private ApplicationContext _context { get; set; }
		public BaseRepository(ApplicationContext context)
		{
			_context = context;
        }
		public List<DbModel> GetAll()
		{
			return _context.Set<DbModel>().ToList();
		}
        public DbModel GetById(Guid Id)
		{
			return _context.Set<DbModel>().FirstOrDefault(t => t.Id == Id);
		}
        public DbModel Update(DbModel model)
		{
			var toUpdate = _context.Set<DbModel>().FirstOrDefault(t => t.Id == model.Id);
			if (toUpdate != null)
			{
				toUpdate = model;
			}
			_context.Set<DbModel>().Update(toUpdate);
			_context.SaveChanges();
			return model;
		}
        public void DeleteById(DbModel model)
		{
			_context.Set<DbModel>().Remove(model);
			_context.SaveChanges();
		}
    }
}
