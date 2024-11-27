using TrainSystem.Models;
using TrainSystem.Models.ModelViews;
using TrainSystem.Repositories;
using TrainSystem.Tests.DatabaseTests;
using Xunit.Abstractions;

namespace TrainSystem.Tests.ServicesTests
{
    public class BaseRepositoryTest
    {
        private MockApplicationContext _applicationContext { get; set; }
        private IBaseRepository<PlaceModel> _placeRepository { get; set; }
        private IBaseRepository<WagonModel> _wagonRepository { get; set; }
        private IBaseRepository<ConditionModel> _conditionRepository { get; set; }
        private IBaseRepository<WagonConditionModel> _wagonConditionRepository { get; set; }
        private IBaseRepository<UserTicketModel> _userTicketRepository { get; set; }
        private ITestOutputHelper _output { get; set; }
        public BaseRepositoryTest(ITestOutputHelper output)
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
        public void GetByIdTest()
        {
            PlaceViewModel target1 = new PlaceViewModel
            {
                PlaceName = "1",
                IsOccupied = true
            };
            PlaceViewModel target2 = new PlaceViewModel
            {
                PlaceName = "2",
                IsOccupied = false
            };
            var res = _placeRepository.GetById(Utility.ToGuid(1));
            Assert.NotNull(res);
            Assert.Equal(res.PlaceName,"1");
        }
    }
}
