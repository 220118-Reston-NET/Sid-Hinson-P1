using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public interface ISQLCRepository
    {
        /// <summary>
        /// Add Customers to DB
        /// </summary>
        /// <param name="p_cust"></param> Customer Object
        /// <returns>Customer Added</returns>
        public Customers AddCustomers(Customers p_cust);
        /// <summary>
        /// Will Get All Customers in DB
        /// </summary>
        /// <returns>Returns List</returns>
        public List<Customers> GetAllCustomers();
    }
    





        public interface ISQLPRepository
    {
        /// <summary>
        /// Add Products to DB
        /// </summary>
        /// <param name="p_prod"></param> Customer Object
        /// <returns>Product Added</returns>
        public Products AddProducts(Products p_prod);

        /// <summary>
        /// Will Get All Products in DB
        /// </summary>
        /// <returns>Returns List</returns>
        public List<Products> GetAllProducts();

    }
    





        public interface ISQLSRepository
    {
        /// <summary>
        /// Add Storefronts to DB
        /// </summary>
        /// <param name="p_store"></param> Customer Object
        /// <returns>Storefront Added</returns>
        public StoreFronts AddStoreFronts(StoreFronts p_store);
        /// <summary>
        /// Will Get All Storefronts in DB
        /// </summary>
        /// <returns>Returns List</returns>
        public List<StoreFronts> GetAllStoreFronts();
        /// <summary>
        /// Pulls a Single StoreFront ID to Grab History
        /// </summary>
        /// <param name="p_store"></param>
        /// <returns></returns>
        public List<StoreFronts> GetStoreHist(int p_store);
    }
    





        public interface ISQLORepository
    {
        // /// <summary>
        // /// Add Orders to DB
        // /// </summary>
        // /// <param name="p_ord"></param> Customer Object
        // /// <returns>Order Added</returns>
        public Orders AddOrders(Orders p_ord);

        /// <summary>
        /// Will Get All Orders in DB
        /// </summary>
        /// <returns>Returns List</returns>
        public List<Orders> GetAllOrders();
        /// <summary>
        /// Gets a Comprehensive Order List for a Customer
        /// </summary>
        /// <returns></returns>
        public List<Orders> GetOrdersHistory(int p_custID);
        /// <summary>
        /// Gets a Single Detailed Order History
        /// </summary>
        /// <param name="p_ordID"></param>
        /// <returns></returns>
        public Orders GetOrderHistory(int p_ordID);
        /// <summary>
        /// Add Items to LineItem
        /// </summary>
        /// <param name="p_line"></param>
        /// <returns></returns>
        public LineItems AddLineItems(LineItems p_line);

    }
    



        public interface ISQLInvRepository
    {
        /// <summary>
        /// Adds Inventory to DB
        /// </summary>
        /// <param name="p_inv"></param>
        /// <returns>inventory obj</returns>
        public Inventory AddInventory(Inventory p_inv);
        /// <summary>
        /// Gets All Inventory
        /// </summary>
        /// <returns></returns>
        public List<Inventory> GetAllInventory();
        /// <summary>
        /// Updates Inventory with a constructed INV object
        /// </summary>
        /// <param name="p_inv"></param>
        /// <returns></returns>
        public Inventory UpdateInventory(Inventory p_inv);

    }
}