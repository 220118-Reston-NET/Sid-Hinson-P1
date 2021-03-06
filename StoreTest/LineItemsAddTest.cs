using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{
    /// <summary>
    /// Should Add LineItems
    /// </summary>
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
            Mock<ISqloRepository> mockRepo = new Mock<ISqloRepository>();

            //Mock GetAllLineItems
            mockRepo.Setup(repo => repo.AddLineItems(line)).Returns(line);
            IOrdersBL ordBL = new OrdersBL(mockRepo.Object);

            //Act
            LineItems line2 = ordBL.AddLineItems(line);

           //Assert
           Assert.Same(line, line2);
           Assert.Equal(line.ProductQuantity, line2.ProductQuantity);
           Assert.NotNull(line2);

       }
    }
}