using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;
using TrainSystem.Database;
using Moq;
using TrainSystem.Models.ModelDatabase;

namespace TrainSystem.Tests
{

    internal class MockApplicationContext
    {
        public Mock<ApplicationContext> _mockContext { get; private set; }
        public MockApplicationContext()
        {
            _mockContext = new Mock<ApplicationContext>();

            _mockContext.Setup(m => m.Set<PlaceModel>()).ReturnsDbSet(TestContextData.GetPlacesData());
            _mockContext.Setup(m => m.Set<WagonModel>()).ReturnsDbSet(TestContextData.GetWagonsData());
            _mockContext.Setup(m => m.Set<ConditionModel>()).ReturnsDbSet(TestContextData.GetConditionsData());
            _mockContext.Setup(m => m.Set<WagonConditionModel>()).ReturnsDbSet(TestContextData.GetWagonConditionsData());
            _mockContext.Setup(m => m.Set<UserTicketModel>()).ReturnsDbSet(TestContextData.GetUserTicketData());
            _mockContext.Setup(m => m.Set<UserModel>()).ReturnsDbSet(TestContextData.GetUserData());
            _mockContext.Setup(m => m.Set<TrainModel>()).ReturnsDbSet(TestContextData.GetTrainData());
            _mockContext.Setup(m => m.Set<TicketModel>()).ReturnsDbSet(TestContextData.GetTicketData());
            _mockContext.Setup(m => m.Set<RouteModel>()).ReturnsDbSet(TestContextData.GetRouteData());
            _mockContext.Setup(m => m.Set<DateModel>()).ReturnsDbSet(TestContextData.GetDateData());
        }
    }
    class TestContextData
    {
        public static List<PlaceModel> GetPlacesData()
        {
            return new List<PlaceModel>
            {
                new PlaceModel{Id=Utility.ToGuid(1), PlaceName="B1", WagonId=Utility.ToGuid(1)},
                new PlaceModel{Id=Utility.ToGuid(2), PlaceName="B2", WagonId=Utility.ToGuid(1)}
            };
        }
        public static List<WagonModel> GetWagonsData()
        {
            return new List<WagonModel>
            {
                new WagonModel{Id=Utility.ToGuid(1),WagonName="TestName",WagonType="TestType"}
            };
        }
        public static List<ConditionModel> GetConditionsData()
        {
            return new List<ConditionModel>
            {
                new ConditionModel{ConditionName=Condition.BioToilet, Id=Utility.ToGuid(1)},
                new ConditionModel{ConditionName=Condition.Conditioner, Id=Utility.ToGuid(2)},
                new ConditionModel{ConditionName=Condition.AllowPets, Id=Utility.ToGuid(3)}
            };
        }
        public static List<WagonConditionModel> GetWagonConditionsData()
        {
            return new List<WagonConditionModel>
            {
                new WagonConditionModel{Id=Utility.ToGuid(1), WagonId=Utility.ToGuid(1), ConditionId=Utility.ToGuid(1)},
                new WagonConditionModel{Id=Utility.ToGuid(2), WagonId=Utility.ToGuid(1), ConditionId=Utility.ToGuid(2)},
                new WagonConditionModel{Id=Utility.ToGuid(3), WagonId=Utility.ToGuid(1), ConditionId=Utility.ToGuid(3)}
            };
        }
        public static List<UserTicketModel> GetUserTicketData()
        {
            return new List<UserTicketModel>
            {
                new UserTicketModel{Id=Utility.ToGuid(1),TicketId=Utility.ToGuid(1),UserId=Utility.ToGuid(1),IsBuying=true},
                new UserTicketModel{Id=Utility.ToGuid(2),TicketId=Utility.ToGuid(2),UserId=Utility.ToGuid(1),IsBuying=true}
            };
        }
        public static List<UserModel> GetUserData()
        {
            return new List<UserModel>
            {
                new UserModel{Id=Utility.ToGuid(1), Email="maxim@example.com", Password="Password123", FamilyName="Андронов", Name="Максим", Surname="Дмитриевич"},
                new UserModel{Id=Utility.ToGuid(2), Email="rusanov@example.com", Password="Securepassword", FamilyName="Русанов", Name="Александр", Surname="Антонович"},
                new UserModel{Id=Utility.ToGuid(3), Email="sobakin@example.com", Password="Mypassword", FamilyName="Собакин", Name="Дмитрий", Surname="Александрович"}
            };
        }
        public static List<TrainModel> GetTrainData()
        {
            return new List<TrainModel>
            {
                new TrainModel{Id = Utility.ToGuid(1),TrainName = "Express 1",TrainType="High Speed"}
            };
        }
        public static List<TicketModel> GetTicketData()
        {
            return new List<TicketModel>
            {

            };
        }
        public static List<RouteModel> GetRouteData()
        {
            return new List<RouteModel>
            {
                new RouteModel { Id=Utility.ToGuid(1),PointStart="Moscow",PointEnd="Saint Petersburg"}
            };
        }
        public static List<DateModel> GetDateData()
        {
            return new List<DateModel>
            {
                new DateModel{Id=Utility.ToGuid(1), DateStart=new DateTime(2024,12,1,10,0,0), DateEnd=new DateTime(2024,12,1,14,0,0)},
                new DateModel{Id=Utility.ToGuid(2), DateStart=new DateTime(2024,12,2,8,30,0), DateEnd=new DateTime(2024,12,2,12,30,0)},
                new DateModel{Id=Utility.ToGuid(3), DateStart=new DateTime(2024,12,3,16,0,0), DateEnd=new DateTime(2024,12,3,20,0,0)},
            };
        }
    }
}
