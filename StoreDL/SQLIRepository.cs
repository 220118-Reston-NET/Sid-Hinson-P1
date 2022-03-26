using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public interface ISqlcRepository
    {
        /// <summary>
        /// Add Customers to DB
        /// </summary>
        /// <param name="p_cust"></param> Customer Object
        /// <returns>Customer Added</returns>
        Customers AddCustomers(Customers p_cust);
        /// <summary>
        /// Will Get All Customers in DB
        /// </summary>
        /// <returns>Returns List</returns>
        List<Customers> GetAllCustomers();
    }
    





        public interface ISqlpRepository
    {
        /// <summary>
        /// Add Products to DB
        /// </summary>
        /// <param name="p_prod"></param> Customer Object
        /// <returns>Product Added</returns>
        Products AddProducts(Products p_prod);

        /// <summary>
        /// Will Get All Products in DB
        /// </summary>
        /// <returns>Returns List</returns>
        List<Products> GetAllProducts();

    }
    





        public interface ISqLsRepository
    {
        /// <summary>
        /// Add Storefronts to DB
        /// </summary>
        /// <param name="p_store"></param> Customer Object
        /// <returns>Storefront Added</returns>
        StoreFronts AddStoreFronts(StoreFronts p_store);
        /// <summary>
        /// Will Get All Storefronts in DB
        /// </summary>
        /// <returns>Returns List</returns>
        List<StoreFronts> GetAllStoreFronts();
        /// <summary>
        /// Pulls a Single StoreFront ID to Grab History
        /// </summary>
        /// <param name="p_store"></param>
        /// <returns></returns>
        List<StoreFronts> GetStoreHist(int p_store);
    }
    





        public interface ISqloRepository
    {
        // /// <summary>
        // /// Add Orders to DB
        // /// </summary>
        // /// <param name="p_ord"></param> Customer Object
        // /// <returns>Order Added</returns>
        Orders AddOrders(Orders p_ord);

        /// <summary>
        /// Will Get All Orders in DB
        /// </summary>
        /// <returns>Returns List</returns>
        List<Orders> GetAllOrders();
        /// <summary>
        /// Gets a Comprehensive Order List for a Customer
        /// </summary>
        /// <returns></returns>
        List<Orders> GetOrdersHistory(int p_custID);
        /// <summary>
        /// Gets a Single Detailed Order History
        /// </summary>
        /// <param name="p_ordID"></param>
        /// <returns></returns>
        Orders GetOrderHistory(int p_ordID);
        /// <summary>
        /// Add Items to LineItem
        /// </summary>
        /// <param name="p_line"></param>
        /// <returns></returns>
        LineItems AddLineItems(LineItems p_line);
        /// <summary>
        /// Finds Line Items by Order ID
        /// </summary>
        /// <param name="p_ordID"></param>
        /// <returns></returns>
        List<LineItems> SearchLineItems(int p_ordID);
        /// <summary>
        /// Grabs All LineItems
        /// </summary>
        /// <returns></returns>
        List<LineItems> GetAllLineItems();
        /// <summary>
        /// Gets All Inventory
        /// </summary>
        /// <returns></returns>
                /// <summary>
        /// Adds Inventory to DB
        /// </summary>
        /// <param name="p_inv"></param>
        /// <returns>inventory obj</returns>
        Inventory AddInventory(Inventory p_inv);
        /// <summary>
        /// Gets All Inventory
        /// </summary>
        /// <returns></returns>
        List<Inventory> GetAllInventory();
        /// <summary>
        /// Updates Inventory with a constructed INV object
        /// </summary>
        /// <param name="p_inv"></param>
        /// <returns></returns>
        Inventory UpdateInventory(Inventory p_inv);
    }
    


}