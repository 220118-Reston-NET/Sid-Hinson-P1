using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{
    public class LineItemsBLTest
    {
        [Fact]

       public void Should_Get_All_LineItems()
       {
            //Arrange
            int productQuantity = 30;
            double price = 23.00;
            int storeID = 1;

            LineItems line1 = new LineItems()
            {
                ProductQuantity = productQuantity,
                Price = price,
                StoreID = storeID
            };

            List<LineItems> expectedlistofline = new List<LineItems>();
            expectedlistofline.Add(line1);

            //Mock The Repo that is a dependency
            Mock<ISqloRepository> mockRepo = new Mock<ISqloRepository>();
            //Mock GetAllLineItems
            mockRepo.Setup(repo => repo.GetAllLineItems()).Returns(expectedlistofline);

            IOrdersBL ordBL = new OrdersBL(mockRepo.Object);

           //Act
           List<LineItems> actuallinelist = ordBL.GetAllLineItems();

           //Assert
           Assert.Same(expectedlistofline, actuallinelist);
           Assert.Equal(expectedlistofline[0].StoreID, actuallinelist[0].StoreID);
       }
    }
}