using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{
    public class ProductBLTest
    {
        [Fact]

       public void Should_Get_All_Products()
       {
           //Arrange
            int storeID = 1;
            string productName = "TurboGrafx"; 
            string productCompany = "NEC";


            Products Product1 = new Products()
            {
                    StoreID = storeID,
                    ProductName = productName,
                    ProductCompany = productCompany

            };

            List<Products> expectedlistofprod = new List<Products>();
            expectedlistofprod.Add(Product1);

            //Mock The Repo that is a dependency
            Mock<ISQL_PRepository> mockRepo = new Mock<ISQL_PRepository>();
            //Mock GetAllProducts
            mockRepo.Setup(repo => repo.GetAllProducts()).Returns(expectedlistofprod);

            IProductsBL prodBL = new ProductsBL(mockRepo.Object);

           //Act
           List<Products> actualProductlist = prodBL.GetAllProducts();

           //Assert
           Assert.Same(expectedlistofprod, actualProductlist);
           Assert.Equal(expectedlistofprod[0].ProductName, actualProductlist[0].ProductName);
       }
    }
}