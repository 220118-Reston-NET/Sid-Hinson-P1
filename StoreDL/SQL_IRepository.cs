using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public interface ISQL_CRepository
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
    





        public interface ISQL_PRepository
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
    





        public interface ISQL_SRepository
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
        public List<StoreFronts> GetCompStoreHist(int p_store);
    }
    





        public interface ISQL_ORepository
    {
        /// <summary>
        /// Add Orders to DB
        /// </summary>
        /// <param name="p_ord"></param> Customer Object
        /// <returns>Order Added</returns>
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
        public List<Orders> GetCompOrderHist(int p_custID);
        /// <summary>
        /// Updates Order Status
        /// </summary>
        /// <param name="p_ordID"></param>
        /// <param name="p_stat"></param>
        public void UpdateOrdStat(int p_ordID, string p_stat);
        /// <summary>
        /// Add Items to LineItem
        /// </summary>
        /// <param name="p_line"></param>
        /// <returns></returns>
        public LineItems AddLineItems(LineItems p_line);
        /// <summary>
        /// Gets All Line Items
        /// </summary>
        /// <returns></returns>
        public List<LineItems> GetAllLineItems();

    }
    



        public interface ISQL_InvRepository
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