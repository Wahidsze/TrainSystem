using TrainSystem.Models.ModelDatabase;
using TrainSystem.Repositories;
using TrainSystem.Services;
using TrainSystem.Models.ModelViews;

namespace TrainSystem.Tests.ServicesTests
{
    public class TicketServiceTests
    {
        private MockApplicationContext _context { get; set; }
        private TicketRepository _repository { get; set; }
        public TicketServiceTests()
        {
            _context = new MockApplicationContext();
            _repository = new TicketRepository(_context._mockContext.Object);
        }
        [Fact]
        public void GetAllRouteTest()
        {
            var target = new List<RouteModel>
            {
                new RouteModel { Id = Utility.ToGuid(1), PointStart = "Moscow", PointEnd = "Saint Petersburg" },
                new RouteModel { Id = Utility.ToGuid(2), PointStart = "Perm", PointEnd = "Ekaterinburg" }
            };
            var ticketService = new TicketService(_context._mockContext.Object);
            var result = ticketService.GetAllRoute();
            Assert.Equal(result[0].PointStart, target[0].PointStart);
            Assert.Equal(result[0].PointEnd, target[0].PointEnd);
            Assert.Equal(result[1].PointStart, target[1].PointStart);
            Assert.Equal(result[1].PointEnd, target[1].PointEnd);
        }
        [Fact]
        public void GetTicketsByDateAndPath()
        {
            var dtStart = new DateTime(2024, 12, 1, 10, 0, 0);
            var dtEnd = new DateTime(2024, 12, 1, 14, 0, 0);
            TicketService ticketService = new TicketService(_context._mockContext.Object);
            var target = new TicketViewModel
            {
                TrainName = "Express 1", TrainType = "High Speed",
                DateStart = dtStart, DateEnd = dtEnd,
                PointStart = "Moscow", PointEnd = "Saint Petersburg"
            };
            var result = ticketService.GetTicketsByDateAndPath(dtStart, "Moscow", "Saint Petersburg");
            Assert.Equal(result[0].TrainName, target.TrainName);
            Assert.Equal(result[0].TrainType, target.TrainType);
            Assert.Equal(result[0].DateEnd, target.DateEnd);
            Assert.Equal(result[0].PointStart, target.PointStart);
        }
    }
}
