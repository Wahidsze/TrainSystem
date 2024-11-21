using TrainSystem.Repositories;
using TrainSystem.Models;
using TrainSystem.Models.ModelViews;
using Microsoft.IdentityModel.Tokens;

namespace TrainSystem.Services
{
    public class TicketService : ITicketService
    {
        private ITicketBuilder _builder { get; }
        private IBaseRepository<RouteModel> _routes { get; set; }
        private IBaseRepository<DateModel> _dates { get; set; }
        private IBaseRepository<TicketModel> _tickets { get; set; }
        public TicketService()
        {
            _builder = new TicketBuilder();
        }
        public List<RouteModel> GetAllCities() 
        {
            return _routes.GetAll();
        }
        public List<TicketViewModel> GetTicketsByDateAndPath(DateTime DateStart,String PointStart,String PointEnd)
        {
            var route = _routes.GetSet()
                .Where(r => r.PointStart == PointStart && r.PointEnd == PointEnd);
            var dates = _dates.GetSet()
                .Where(d => d.DateStart == DateStart);
            var tickets = _tickets.GetSet()
                .Where(t => route.Any(r => r.Id == t.RouteId) && dates.Any(d => d.Id == t.DateId))
                .GroupBy(t => new 
                {
                    t.TrainId,
                    t.DateId,
                    t.RouteId
                });
            List<TicketViewModel> result = new List<TicketViewModel>();
            foreach (var ticket in tickets)
            {
                result.Append(_builder
                    .SetDate(ticket.Key.DateId)
                    .SetRoute(ticket.Key.RouteId)
                    .SetTrain(ticket.Key.TrainId)
                    .SetWagons(ticket.Select(t =>t.PlaceId).ToList())
                    .Build());
            }
            return result;
            //shaurmommy and shaurdaddy return shaurson
        }


    }
}
