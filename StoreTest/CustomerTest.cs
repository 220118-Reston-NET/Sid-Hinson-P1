using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{
    /// <summary>
    /// Should Set Valid Data
    /// </summary>

    public class CustomerTest
    {
        [Fact]

        public void Should_Set_Valid_Data()
        {
            //Arrange
            Customers cust = new Customers();
            string firstName = "John";
            string lastname = "Harrison";

            //Act
            cust.CFirstName = firstName;
            cust.CLastName = lastname;

            //Assert
            Assert.NotNull(cust.CFirstName);
            Assert.NotNull(cust.CLastName);
            Assert.Equal(firstName, cust.CFirstName);
            Assert.Equal(lastname, cust.CLastName);
            
        }

    }
}