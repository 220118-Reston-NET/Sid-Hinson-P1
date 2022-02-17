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
            string orderdate = "10211980";
            string orderstatus = "FULFILLED";

            //Act
            ord.OrderDate = orderdate;
            ord.OrderStatus = orderstatus;

            //Assert
            Assert.NotNull(ord.OrderDate);
            Assert.NotNull(ord.OrderStatus);
            Assert.Equal(orderdate, ord.OrderDate);
            Assert.Equal(orderstatus, ord.OrderStatus);
            
        }

    }
}