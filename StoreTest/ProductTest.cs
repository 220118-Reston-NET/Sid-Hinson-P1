using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{

    public class ProductTest
    {
        [Fact]

        public void Should_Set_Valid_Data()
        {
            //Arrange
            Products prod = new Products();
            string prodname = "GENESIS";
            string prodcomp = "SEGA";

            //Act
            prod.ProductName = prodname;
            prod.ProductCompany = prodcomp;

            //Assert
            Assert.NotNull(prod.ProductName);
            Assert.NotNull(prod.ProductCompany);
            Assert.Equal(prodname, prod.ProductName);
            Assert.Equal(prodcomp, prod.ProductCompany);
            
        }

    }
}