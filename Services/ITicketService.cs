using TrainSystem.Models;
using TrainSystem.Models.ModelViews;
namespace TrainSystem.Services
{
    public interface ITicketService
    {
        public List<RouteModel> GetAllCities();
        public List<TicketViewModel> GetTicketsByDateAndPath(DateTime DateStart, String PointStart, String PointEnd);
    }
}
