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

    }
}