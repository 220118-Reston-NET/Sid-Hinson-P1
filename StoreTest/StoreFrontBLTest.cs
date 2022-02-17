using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{
    public class StoreFrontBLTest
    {
        [Fact]

       public void Should_Get_All_StoreFronts()
       {
           //Arrange
            string storeAddress = "742 CHERRY STREET";
            string storeZipCode = "30210";

            StoreFronts StoreFront1 = new StoreFronts()
            {
                StoreAddress = storeAddress,
                StoreZipCode = storeZipCode
            };

            List<StoreFronts> expectedlistofstorefront = new List<StoreFronts>();
            expectedlistofstorefront.Add(StoreFront1);

            //Mock The Repo that is a dependency
            Mock<ISQL_SRepository> mockRepo = new Mock<ISQL_SRepository>();
            //Mock GetAllStoreFronts
            mockRepo.Setup(repo => repo.GetAllStoreFronts()).Returns(expectedlistofstorefront);

            IStoreFrontsBL storefBL = new StoreFrontsBL(mockRepo.Object);

           //Act
           List<StoreFronts> actualStoreFrontlist = storefBL.GetAllStoreFronts();

           //Assert
           Assert.Same(expectedlistofstorefront, actualStoreFrontlist);
           Assert.Equal(expectedlistofstorefront[0].StoreAddress, actualStoreFrontlist[0].StoreAddress);
       }
    }
}