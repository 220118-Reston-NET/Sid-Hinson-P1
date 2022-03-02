using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{
    /// <summary>
    /// Should Add Products TEST
    /// </summary>
    public class ProductBLAddTest
    {
        [Fact]
        public void Should_Add_Products()
       {

            //Arrange
            string productName = "SNES";
            string productCompany = "NINTENDO";
            double productPrice = 200.00;
            string productDescription = "RETRO GAME SYSTEM";
            string productCategory = "SYSTEM";

            Products p_prod = new Products()
            {
                ProductName = productName,
                ProductCompany = productCompany,
                ProductPrice = productPrice,
                ProductDescription = productDescription,
                ProductCategory = productCategory
            };

            //Mock The Repo that is a dependency
            Mock<ISqlpRepository> mockRepo = new Mock<ISqlpRepository>();

            //Mock GetAllProducts
            mockRepo.Setup(repo => repo.AddProducts(p_prod)).Returns(p_prod);
            ProductsBL prodBL = new ProductsBL(mockRepo.Object);

            //Act
            //Act
            Products p_prod2 = prodBL.AddProducts(p_prod);

           //Assert
           Assert.Same(p_prod, p_prod2);
           Assert.Equal(p_prod.ProductPrice, p_prod2.ProductPrice);
           Assert.NotNull(p_prod2);
       }
    }
}