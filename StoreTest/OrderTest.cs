using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{

    public class OrderTest
    {
        /// <summary>
        /// Should Set Valid Order Data
        /// </summary>
        [Fact]

        public void Should_Set_Valid_Data()
        {
            //Arrange
            Orders ord = new Orders();
            double ordertotal = 230.00;
            string orderstatus = "FULFILLED";

            //Act
            ord.OrderTotal = ordertotal;
            ord.OrderStatus = orderstatus;

            //Assert
            Assert.NotNull(ord.OrderStatus);
            Assert.Equal(ordertotal, ord.OrderTotal);
            Assert.Equal(orderstatus, ord.OrderStatus);
            
        }

        /// <summary>
        /// Should Get Correct Order History
        /// </summary>
        [Fact]

        public void Should_Get_Correct_Store_Orders_History()
        {
            //Arrange

            int p_ordCustID = 1;
            List<Orders> expectedlistoforders = new List<Orders>();
            
            //Mock The Repo that is a dependency
            Mock<ISqloRepository> mockRepo = new Mock<ISqloRepository>();
            
            //Mock GetAllOrders
            mockRepo.Setup(repo => repo.GetOrdersHistory(p_ordCustID)).Returns(expectedlistoforders);
            IOrdersBL ordBL = new OrdersBL(mockRepo.Object);

           //Act
           List<Orders> actualOrderlist = ordBL.GetOrdersHistory(p_ordCustID);

           //Assert
           Assert.Same(expectedlistoforders, actualOrderlist);
           Assert.NotNull(actualOrderlist);
        }

    }
}