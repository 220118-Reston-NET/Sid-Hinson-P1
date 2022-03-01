using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{

    public class LineItemsTest
    {
        [Fact]

        public void Should_Set_Valid_Data()
        {
            //Arrange
            LineItems line = new LineItems();
            int storeID = 1;
            int productQuantity = 25;
            double price = 25.00;

            //Act
            line.StoreID = storeID;
            line.ProductQuantity = productQuantity;
            line.Price = price;

            //Assert
            Assert.Equal(storeID ,line.StoreID);
            Assert.Equal(productQuantity, line.ProductQuantity);
            Assert.Equal(price, line.Price);
            
        }

    }
}