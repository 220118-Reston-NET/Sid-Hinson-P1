using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{

    public class InventoryTest
    {
        [Fact]

        public void Should_Set_Valid_Data()
        {
            //Arrange
            Inventory inv = new Inventory();
            int storeID = 2;
            int productID = 2;

            //Act
            inv.StoreID = storeID;
            inv.ProductID = productID;

            //Assert
            Assert.Equal(storeID, inv.StoreID);
            Assert.Equal(productID, inv.ProductID);
            
        }

    }
}