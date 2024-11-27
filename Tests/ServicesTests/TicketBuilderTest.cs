using TrainSystem.Models;
using TrainSystem.Models.ModelViews;
using TrainSystem.Repositories;
using TrainSystem.Tests.DatabaseTests;
using Xunit.Abstractions;

namespace TrainSystem.Tests.ServicesTests
{
    public class TicketBuilderTest
    {
        private MockApplicationContext _applicationContext { get; set; }
        private IBaseRepository<PlaceModel> _placeRepository { get; set; }
        private IBaseRepository<WagonModel> _wagonRepository { get; set; }
        private IBaseRepository<ConditionModel> _conditionRepository { get; set; }
        private IBaseRepository<WagonConditionModel> _wagonConditionRepository { get; set; }
        private IBaseRepository<UserTicketModel> _userTicketRepository { get; set; }
        private ITestOutputHelper _output { get; set; }
        public TicketBuilderTest(ITestOutputHelper output)
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
        public void BuildCreateTicketViewModel()
        {
            TicketViewModel target = new TicketViewModel
            {
                TrainName = "TrainNameTest",
                TrainType = "TrainTypeTest",

            };
        //public String TrainName { get; set; }
        //public String TrainType { get; set; }
        //public List<WagonViewModel> Wagons { get; set; }
        //public DateTime DateStart { get; set; }
        //public DateTime DateEnd { get; set; }
        //public String PointStart { get; set; }
        //public String PointEnd { get; set; }
    }
    }
}
