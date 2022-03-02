using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{
    public class OrderBLTest
    {
        [Fact]

       public void Should_Get_All_Orders()
       {
           //Arrange
            
            int orderCustID = 1;
            int orderStoreID = 1;
            string orderStatus = "FULFILLED";
            double orderTotal = 50.00;
  

            Orders Order1 = new Orders()
            {
                    OrderCustID = orderCustID,
                    OrderStoreID = orderStoreID,
                    OrderStatus = orderStatus,
                    OrderTotal = orderTotal
            };

            List<Orders> expectedlistoforders = new List<Orders>();
            expectedlistoforders.Add(Order1);

            //Mock The Repo that is a dependency
            Mock<ISqloRepository> mockRepo = new Mock<ISqloRepository>();
            //Mock GetAllOrders
            mockRepo.Setup(repo => repo.GetAllOrders()).Returns(expectedlistoforders);

            IOrdersBL ordBL = new OrdersBL(mockRepo.Object);

           //Act
           List<Orders> actualOrderlist = ordBL.GetAllOrders();

           //Assert
           Assert.Same(expectedlistoforders, actualOrderlist);
           Assert.Equal(expectedlistoforders[0].OrderID, actualOrderlist[0].OrderID);
       }
    }
}