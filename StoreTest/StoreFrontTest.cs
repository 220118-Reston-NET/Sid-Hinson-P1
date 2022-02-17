using System.Collections.Generic;
using Moq;
using StoreDL;
using StoreBL;
using StoreModel;
using Xunit;

namespace StoreTest
{

    public class StoreFrontTest
    {
        [Fact]

        public void Should_Set_Valid_Data()
        {
            //Arrange
            StoreFronts store = new StoreFronts();
            string storestate = "GA";
            string storecity = "Macon";

            //Act
            store.StoreState = storestate;
            store.StoreCity = storecity;

            //Assert
            Assert.NotNull(store.StoreState);
            Assert.NotNull(store.StoreCity);
            Assert.Equal(storestate, store.StoreState);
            Assert.Equal(storecity, store.StoreCity);
            
        }

    }
}