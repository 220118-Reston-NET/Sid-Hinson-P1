using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{
    public class StoreFrontBLAddTest
    {
        [Fact]
        public void Should_Add_StoreFronts()
       {

            //Arrange
            string storeAddress = "111 Romeiser Drive";
            string storeState = "GA";

            StoreFronts p_store = new StoreFronts()
            {
                StoreAddress = storeAddress,
                StoreState = storeState
            };

            //Mock The Repo that is a dependency
            Mock<ISQLSRepository> mockRepo = new Mock<ISQLSRepository>();

            //Mock GetAllCustomers
            mockRepo.Setup(repo => repo.AddStoreFronts(p_store)).Returns(p_store);
            StoreFrontsBL storeBL = new StoreFrontsBL(mockRepo.Object);

            //Act
           StoreFronts p_store2 = new StoreFronts()
            {
                StoreAddress = storeAddress,
                StoreState = storeState
            };
            storeBL.AddStoreFronts(p_store2);

           //Assert
           Assert.Same(p_store.StoreAddress,p_store2.StoreAddress);
           Assert.Equal(p_store.StoreState,p_store2.StoreState);
       }
    }
}