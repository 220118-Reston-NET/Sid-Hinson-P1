using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{
    public class CustomerBLTest
    {
        [Fact]

       public void Should_Get_All_Customers()
       {
           //Arrange
            string FirstName = "STEPHEN";
            string LastName = "STRANGE";
            string DateofBirth = "11181930";
            string Address = "117A BlEECKER STREET";
            string State = "NY";
            string City = "NEW YORK CITY";
            string Zipcode = "10011";
            string Country = "USA";
            string Email = "STEPHEN.STRANGE@AOL.COM";
            string Password = "mordoisajerk";

            Customers customer1 = new Customers()
            {
                CFirstName = FirstName,
                CLastName = LastName,
                CDateofBirth = DateofBirth,
                CustomerAddress = Address,
                CustomerState = State,
                CustomerCity = City,
                CustomerZipcode = Zipcode,
                CustCountry = Country,
                CustomerEmail = Email,
                CPassword = Password
            };

            List<Customers> expectedlistofcust = new List<Customers>();
            expectedlistofcust.Add(customer1);

            //Mock The Repo that is a dependency
            Mock<ISQL_CRepository> mockRepo = new Mock<ISQL_CRepository>();
            //Mock GetAllCustomers
            mockRepo.Setup(repo => repo.GetAllCustomers()).Returns(expectedlistofcust);

            ICustomersBL custBL = new CustomersBL(mockRepo.Object);

           //Act
           List<Customers> actualcustomerlist = custBL.GetAllCustomers();

           //Assert
           Assert.Same(expectedlistofcust, actualcustomerlist);
           Assert.Equal(expectedlistofcust[0].CFirstName, actualcustomerlist[0].CFirstName);
       }
    }
}