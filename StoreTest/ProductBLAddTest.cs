using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{
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
            Mock<ISQLPRepository> mockRepo = new Mock<ISQLPRepository>();

            //Mock GetAllCustomers
            mockRepo.Setup(repo => repo.AddProducts(p_prod)).Returns(p_prod);
            ProductsBL prodBL = new ProductsBL(mockRepo.Object);

            //Act
           Products p_prod2 = new Products()
            {
                ProductName = productName,
                ProductCompany = productCompany,
                ProductPrice = productPrice,
                ProductDescription = productDescription,
                ProductCategory = productCategory
            };
            prodBL.AddProducts(p_prod2);

           //Assert
           Assert.Same(p_prod.ProductName, p_prod2.ProductName);
           Assert.Same(p_prod.ProductCompany, p_prod2.ProductCompany);
           Assert.Same(p_prod.ProductDescription, p_prod2.ProductDescription);
           Assert.Same(p_prod.ProductCategory, p_prod2.ProductCategory);
           Assert.Equal(p_prod.ProductPrice, p_prod2.ProductPrice);
       }
    }
}