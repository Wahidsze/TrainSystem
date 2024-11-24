using TrainSystem.Repositories;
using TrainSystem.Models.ModelViews;
using TrainSystem.Models.ModelDatabase;
using TrainSystem.Database;

namespace TrainSystem.Services
{
    public class TicketService : ITicketService
    {
        private ITicketBuilder _builder { get; }
        private TicketRepository _repository { get; set; }
        public TicketService(ApplicationContext context)
        {
            _repository = new TicketRepository(context);
            _builder = new TicketBuilder(_repository);
        }
        public List<RouteModel> GetAllRoute() 
        {
            return _repository.GetAllRoute();
        }
        public List<TicketViewModel> GetTicketsByDateAndPath(DateTime DateStart,String PointStart,String PointEnd)
        {
            var tickets = _repository.GroupingTicketsByTrain(DateStart, PointStart, PointEnd);
            List<TicketViewModel> result = new List<TicketViewModel>();
            foreach (var ticket in tickets)
            {
                result.Append(_builder
                    .SetDate(ticket.Key.DateId)
                    .SetRoute(ticket.Key.RouteId)
                    .SetTrain(ticket.Key.TrainId)
                    .SetWagons(ticket.Select(t =>t.Id).ToList())
                    .Build());
            }
            return result;
        }
    }
}
