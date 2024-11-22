using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;
using TrainSystem.Database;
using TrainSystem.Models;
using Moq;


namespace TrainSystem.Tests.DatabaseTests
{

    internal class MockApplicationContext
    {
        public Mock<ApplicationContext> _mockContext { get; private set; }
        public MockApplicationContext()
        {
            _mockContext = new Mock<ApplicationContext>();

            _mockContext.Setup(m => m.Set<PlaceModel>()).ReturnsDbSet(GetPlacesData());
            _mockContext.Setup(m => m.Set<WagonModel>()).ReturnsDbSet(GetWagonsData());
            _mockContext.Setup(m => m.Set<ConditionModel>()).ReturnsDbSet(GetConditionsData());
            _mockContext.Setup(m => m.Set<WagonConditionModel>()).ReturnsDbSet(GetWagonConditionsData());
            _mockContext.Setup(m => m.Set<UserTicketModel>()).ReturnsDbSet(GetUserTicketData());
        }
        private List<PlaceModel> GetPlacesData()
        {
            return new List<PlaceModel>
            {
                new PlaceModel{Id=Utility.ToGuid(1), PlaceName="1", WagonId=Utility.ToGuid(1)},
                new PlaceModel{Id=Utility.ToGuid(2), PlaceName="2", WagonId=Utility.ToGuid(1)}
            };
        }
        private List<WagonModel> GetWagonsData()
        {
            return new List<WagonModel>
            {
                new WagonModel{Id=Utility.ToGuid(1),WagonName="TestName",WagonType="TestType"}
            };
        }
        private List<ConditionModel> GetConditionsData()
        {
            return new List<ConditionModel>
            {
                new ConditionModel{ConditionName=Condition.BioToilet, Id=Utility.ToGuid(1)},
                new ConditionModel{ConditionName=Condition.Conditioner, Id=Utility.ToGuid(2)},
                new ConditionModel{ConditionName=Condition.AllowPets, Id=Utility.ToGuid(3)}
            };
        }
        private List<WagonConditionModel> GetWagonConditionsData()
        {
            return new List<WagonConditionModel>
            {
                new WagonConditionModel{Id=Utility.ToGuid(1), WagonId=Utility.ToGuid(1), ConditionId=Utility.ToGuid(1)},
                new WagonConditionModel{Id=Utility.ToGuid(2), WagonId=Utility.ToGuid(1), ConditionId=Utility.ToGuid(2)},
                new WagonConditionModel{Id=Utility.ToGuid(3), WagonId=Utility.ToGuid(1), ConditionId=Utility.ToGuid(3)}
            };
        }
        private List<UserTicketModel> GetUserTicketData()
        {
            return new List<UserTicketModel>
            {
                new UserTicketModel{Id=Utility.ToGuid(1),TicketId=Utility.ToGuid(1),UserId=Utility.ToGuid(1),IsBuying=true},
                new UserTicketModel{Id=Utility.ToGuid(2),TicketId=Utility.ToGuid(2),UserId=Utility.ToGuid(1),IsBuying=true}
            };
        }
    }
}
