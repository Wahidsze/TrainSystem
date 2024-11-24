using TrainSystem.Models.ModelDatabase;
using TrainSystem.Models.ModelViews;
namespace TrainSystem.Services
{
    public interface ITicketService
    {
        public List<RouteModel> GetAllRoute();
        public List<TicketViewModel> GetTicketsByDateAndPath(DateTime DateStart, String PointStart, String PointEnd);
    }
}
