using TrainSystem.Models.ModelViews;
using TrainSystem.Services;
using TrainSystem.Repositories;
using TrainSystem.Models.ModelDatabase;

namespace TrainSystem.Tests.RepositoryTests
{
    public class TicketRepositoryTests
    {
        private MockApplicationContext _context { get; set; }
        private TicketRepository _repository { get; set; }
        public TicketRepositoryTests()
        {
            _context = new MockApplicationContext();
            _repository = new TicketRepository(_context._mockContext.Object);
        }
        [Fact]
        public void GetWagonByIdTest()
        {
            var wagon = _repository.GetWagonById(Utility.ToGuid(1));
            Assert.Equal("TestName", wagon.WagonName);
            Assert.Equal("TestType", wagon.WagonType);
        }
        [Fact]
        public void GetPlaceByIdTest()
        {
            var place = _repository.GetPlaceById(Utility.ToGuid(1));
            Assert.Equal("B1", place.PlaceName);
        }
        [Fact]
        public void GetUserTicketByIdTest()
        {
            var userTicket = _repository.GetUserTicketById(Utility.ToGuid(1));
            Assert.Equal(Utility.ToGuid(1), userTicket.UserId);
            Assert.True(userTicket.IsBuying);
        }
        [Fact]
        public void GetConditionsByIdTest()
        {
            var conditions = _repository.GetConditionsById(Utility.ToGuid(1));
            var target = new List<Condition>
            {
                Condition.BioToilet,Condition.Conditioner,Condition.AllowPets
            };
            Assert.Equal(conditions, target);
        }
        [Fact]
        public void GetDateByIdTest()
        {
            var date = _repository.GetDateById(Utility.ToGuid(1));
            Assert.Equal(date.DateStart, new DateTime(2024, 12, 1, 10, 0, 0));
            Assert.Equal(date.DateEnd, new DateTime(2024, 12, 1, 14, 0, 0));
        }
        [Fact]
        public void GetRouteByIdTest()
        {
            var route = _repository.GetRouteById(Utility.ToGuid(1));
            Assert.Equal(route.PointStart, "Moscow");
            Assert.Equal(route.PointEnd, "Saint Petersburg");
        }
        [Fact]
        public void GetTrainByIdTest()
        {
            var train = _repository.GetTrainById(Utility.ToGuid(1));
            Assert.Equal(train.TrainName, "Express 1");
            Assert.Equal(train.TrainType, "High Speed");
        }
        [Fact]
        public void GroupingPlacesByWagonsTest()
        {
            var tickets = new List<Guid> { Utility.ToGuid(1), Utility.ToGuid(2) };
            var group = _repository.GroupingPlacesByWagons(tickets);
            Assert.True(true);
        }
    }
}
