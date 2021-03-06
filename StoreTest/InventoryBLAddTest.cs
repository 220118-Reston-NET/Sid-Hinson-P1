using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{
    /// <summary>
    /// Should Add Inventory
    /// </summary>
    public class InventoryBLAddTest
    {
        [Fact]
        public void Should_Add_Inventory()
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
            Mock<ISqloRepository> mockRepo = new Mock<ISqloRepository>();

            //Mock GetAllInventory
            mockRepo.Setup(repo => repo.AddInventory(p_inv)).Returns(p_inv);
            OrdersBL invBL = new OrdersBL(mockRepo.Object);

            //Act
            Inventory p_inv2 = invBL.AddInventory(p_inv);

           //Assert
           Assert.Same(p_inv, p_inv2);
           Assert.Equal(p_inv.StoreID, p_inv2.StoreID);
           Assert.NotNull(p_inv2);
       }
    }
}