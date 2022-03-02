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


        [Fact]

        public void Should_Update_Data()
        {
            
            //Arrange
            
            int storeID = 1;
            int productID = 1;
            int productQuantity = 5;

            Inventory p_inv = new Inventory()
            {
                StoreID = storeID,
                ProductID = productID,
                ProductQuantity = productQuantity 

            };

            //Mock The Repo that is a dependency
            Mock<ISqlInvRepository> mockRepo = new Mock<ISqlInvRepository>();

            //Mock UpdateInventory
            mockRepo.Setup(repo => repo.UpdateInventory(p_inv)).Returns(p_inv);
            InventoryBL invBL = new InventoryBL(mockRepo.Object);

            //Act
            Inventory p_inv2 = invBL.UpdateInventory(p_inv);

            //Assert
            Assert.Same(p_inv, p_inv2);
            Assert.Equal(p_inv.StoreID, p_inv2.StoreID);
            Assert.NotNull(p_inv2);

        }

    }
}