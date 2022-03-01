using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{
    public class LineItemsBLAddTest
    {
        [Fact]
        public void Should_Add_LineItems()
       {

           //Arrange
            int productID = 1;
            int productQuantity = 25;

            LineItems line = new LineItems()
            {
                ProductID = productID,
                ProductQuantity = productQuantity
            };

            //Mock The Repo that is a dependency
            Mock<ISQLORepository> mockRepo = new Mock<ISQLORepository>();

            //Mock GetAllLineItems
            mockRepo.Setup(repo => repo.AddLineItems(line)).Returns(line);
            IOrdersBL ordBL = new OrdersBL(mockRepo.Object);

            //Act
            LineItems line2 = new LineItems()
            {
                ProductID = productID,
                ProductQuantity = productQuantity
            };
            ordBL.AddLineItems(line2);

           //Assert
           Assert.Equal(line.ProductID, line2.ProductID);
           Assert.Equal(line.ProductQuantity, line2.ProductQuantity);

       }
    }
}