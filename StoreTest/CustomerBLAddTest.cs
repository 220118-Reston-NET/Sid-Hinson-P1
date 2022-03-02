using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{
    /// <summary>
    /// Should Add Customers
    /// </summary>
    public class CustomerBLAddTest
    {
        [Fact]
        public void Should_Add_Customer()
       {

           //Arrange
            string FirstName = "STEPHEN";
            string LastName = "STRANGE";
            string Address = "117A BlEECKER STREET";
            string State = "NY";
            string City = "NEW YORK CITY";
            string Zipcode = "10011";
            string Country = "USA";
            string Email = "STEPHEN.STRANGE@AOL.COM";
            string Password = "mordoisajerk";


            Customers p_cust = new Customers()
            {
                CFirstName = FirstName,
                CLastName = LastName,
                CustomerAddress = Address,
                CustomerState = State,
                CustomerCity = City,
                CustomerZipcode = Zipcode,
                CustomerCountry = Country,
                CustomerEmail = Email,
                CPassword = Password
            };

            //Mock The Repo that is a dependency
            Mock<ISqlcRepository> mockRepo = new Mock<ISqlcRepository>();

            //Mock GetAddCustomers
            mockRepo.Setup(repo => repo.AddCustomers(p_cust)).Returns(p_cust);
            ICustomersBL custBL = new CustomersBL(mockRepo.Object);

            Customers p_cust2 = custBL.AddCustomers(p_cust);

           //Assert
           Assert.Same(p_cust, p_cust2);
           Assert.Equal(p_cust.CFirstName, p_cust2.CFirstName);
           Assert.NotNull(p_cust2);

       }
    }
}