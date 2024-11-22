using TrainSystem.Models.ModelViews;
using TrainSystem.Models;
using TrainSystem.Services;
using TrainSystem.Repositories;
using Xunit.Abstractions;
using TrainSystem.Tests.DatabaseTests;

namespace TrainSystem.Tests.ServicesTests
{
    public class WagonBuilderTest
    {
        private MockApplicationContext _applicationContext { get; set; }
        private IBaseRepository<PlaceModel> _placeRepository { get; set; }
        private IBaseRepository<WagonModel> _wagonRepository { get; set; }
        private IBaseRepository<ConditionModel> _conditionRepository { get; set; }
        private IBaseRepository<WagonConditionModel> _wagonConditionRepository { get; set; }
        private IBaseRepository<UserTicketModel> _userTicketRepository { get; set; }
        private ITestOutputHelper _output { get; set; }
        public WagonBuilderTest(ITestOutputHelper output)
        {
            _output = output;
            _applicationContext = new MockApplicationContext();
            _placeRepository = new BaseRepository<PlaceModel>(_applicationContext._mockContext.Object);
            _wagonRepository = new BaseRepository<WagonModel>(_applicationContext._mockContext.Object);
            _conditionRepository = new BaseRepository<ConditionModel>(_applicationContext._mockContext.Object);
            _wagonConditionRepository = new BaseRepository<WagonConditionModel>(_applicationContext._mockContext.Object);
            _userTicketRepository = new BaseRepository<UserTicketModel>(_applicationContext._mockContext.Object);
        }
        [Fact]
        public void SetNameAndTypeTests()
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
            WagonBuilder builder = new WagonBuilder(_placeRepository, _wagonRepository, _conditionRepository,
                _wagonConditionRepository, _userTicketRepository);
            WagonViewModel result = builder.SetNameAndType(Utility.ToGuid(1))
                .SetConditions(Utility.ToGuid(1))
                .SetPlace(new List<PlaceAndTicketId>
                {
                    new PlaceAndTicketId {TicketId=Utility.ToGuid(2), PlaceId=Utility.ToGuid(2)},
                    new PlaceAndTicketId {TicketId=Utility.ToGuid(1), PlaceId=Utility.ToGuid(1)}
                }).Build();
            _output.WriteLine(result.WagonName);
            Assert.Equal(target.WagonName, result.WagonName);
            Assert.Equal(target.WagonType, result.WagonType);
            Assert.Equal(target.WagonConditions, result.WagonConditions);
            Assert.Equal(target.WagonPlacements.Count(), result.WagonPlacements.Count());
        }
    }
}