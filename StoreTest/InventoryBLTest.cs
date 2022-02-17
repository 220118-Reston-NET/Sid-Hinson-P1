using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{
    public class InventoryBLTest
    {
        [Fact]

       public void Should_Get_All_Inventory()
       {
           //Arrange
            int warehouseID =  1;
            int storeID =  1;
            int productID = 0;
            int productQuantity = 0;
   

            Inventory Inventory1 = new Inventory()
            {
                WarehouseID = warehouseID,
                StoreID = storeID,
                ProductID = productID,
                ProductQuantity = productQuantity

            };

            List<Inventory> expectedlistinv = new List<Inventory>();
            expectedlistinv.Add(Inventory1);

            //Mock The Repo that is a dependency
            Mock<ISQL_InvRepository> mockRepo = new Mock<ISQL_InvRepository>();
            //Mock GetAllInventorys
            mockRepo.Setup(repo => repo.GetAllInventory()).Returns(expectedlistinv);

            IInventoryBL invBL = new InventoryBL(mockRepo.Object);

           //Act
           List<Inventory> actualInventorylist = invBL.GetAllInventory();

           //Assert
           Assert.Same(expectedlistinv, actualInventorylist);
           Assert.Equal(expectedlistinv[0].ProductID, actualInventorylist[0].ProductID);
       }
    }
}