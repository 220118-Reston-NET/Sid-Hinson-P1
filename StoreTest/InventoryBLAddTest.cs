using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{
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
            Mock<ISQLInvRepository> mockRepo = new Mock<ISQLInvRepository>();

            //Mock GetAllCustomers
            mockRepo.Setup(repo => repo.AddInventory(p_inv)).Returns(p_inv);
            InventoryBL invBL = new InventoryBL(mockRepo.Object);

            //Act
            Inventory p_inv2 = new Inventory()
            {
                StoreID = storeID,
                ProductID = productID,
                ProductQuantity = productQuantity 

            };
            invBL.AddInventory(p_inv2);

           //Assert
           Assert.Equal(p_inv.ProductID, p_inv2.ProductID);
           Assert.Equal(p_inv.StoreID, p_inv2.StoreID);
       }
    }
}