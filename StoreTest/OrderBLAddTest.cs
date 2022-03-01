using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{
    public class OrdersBLAddTest
    {
        [Fact]
        public void Should_Add_Orders()
       {

           //Arrange
            string orderStatus = "PROCESSING";
            double orderTotal = 250.00;

            Orders p_ord = new Orders()
            {
                OrderStatus = orderStatus,
                OrderTotal = orderTotal
            };

            //Mock The Repo that is a dependency
            Mock<ISQLORepository> mockRepo = new Mock<ISQLORepository>();

            //Mock GetAllCustomers
            mockRepo.Setup(repo => repo.AddOrders(p_ord)).Returns(p_ord);
            OrdersBL ordBL = new OrdersBL(mockRepo.Object);

            //Act
           Orders p_ord2 = new Orders()
            {
                OrderStatus = orderStatus,
                OrderTotal = orderTotal
            };
            ordBL.AddOrders(p_ord2);

           //Assert
           Assert.Same(p_ord.OrderStatus,p_ord2.OrderStatus);
           Assert.Equal(p_ord.OrderTotal,p_ord2.OrderTotal);
       }
    }
}