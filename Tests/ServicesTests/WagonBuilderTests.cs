using TrainSystem.Models.ModelViews;
using TrainSystem.Services;
using TrainSystem.Repositories;
using TrainSystem.Models.ModelDatabase;

namespace TrainSystem.Tests.ServicesTests
{
    public class WagonBuilderTests
    {
        private MockApplicationContext _context { get; set; }
        private TicketRepository _repository { get; set; }
        public WagonBuilderTests()
        {
            _context = new MockApplicationContext();
            _repository = new TicketRepository(_context._mockContext.Object);
        }
        [Fact]
        public void BuildCreateWagonViewModelTest()
        {

            WagonViewModel target = new WagonViewModel
            {
                WagonName = "TestName",
                WagonType = "TestType",
                WagonConditions = new List<Condition>
                {
                    Condition.BioToilet, Condition.Conditioner, Condition.AllowPets
                },
                WagonPlacements = new List<PlaceViewModel>
                {
                    new PlaceViewModel {PlaceName="2", IsOccupied=true},
                    new PlaceViewModel {PlaceName="1", IsOccupied=true}
                }
            };
            WagonBuilder builder = new WagonBuilder(_repository);
            WagonViewModel result = builder.SetNameAndType(Utility.ToGuid(1))
                .SetConditions(Utility.ToGuid(1))
                .SetPlace(new List<PlaceAndTicketId>
                {
                    new PlaceAndTicketId {TicketId=Utility.ToGuid(2), PlaceId=Utility.ToGuid(2)},
                    new PlaceAndTicketId {TicketId=Utility.ToGuid(1), PlaceId=Utility.ToGuid(1)}
                }).Build();
            Assert.Equal(target.WagonName, result.WagonName);
            Assert.Equal(target.WagonType, result.WagonType);
            Assert.Equal(target.WagonConditions, result.WagonConditions);
            Assert.Equal(target.WagonPlacements.Count(), result.WagonPlacements.Count());
        }
    }
}