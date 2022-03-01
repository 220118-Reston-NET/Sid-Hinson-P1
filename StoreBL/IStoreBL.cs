using StoreModel;
namespace StoreBL
{

    public interface ICustomersBL
    {
        /// <summary>
        /// Adds Customer to DB passing a Customer obj
        /// </summary>
        /// <param name="p_custs"></param>
        /// <returns></returns>
        Customers AddCustomers(Customers p_custs);
        /// <summary>
        /// Will return List of objects related to Search query through p_name parameter
        /// </summary>
        /// <param name="p_name"></param>
        /// <returns>Filtered Search Results </returns>
        /// 
        List<Customers> SearchCustomersByName(string p_fname, string p_lname);
        /// <summary>
        /// Gets Customer ID By Email and Password
        /// </summary>
        /// <param name="p_email"></param>
        /// <param name="p_pass"></param>
        /// <returns></returns>
        List<Customers> GetAllCustomers();
        /// <summary>
        /// Returns True if Customer is Admin
        /// </summary>
        /// <param name="p_email"></param>
        /// <param name="p_pass"></param>
        /// <returns></returns>
        bool isAdmin(string p_email, string p_pass);
    }


    public interface IStoreFrontsBL
    {
        /// <summary>
        /// Adds Customer to DB passing a Customer obj
        /// </summary>
        /// <param name="p_sfront"></param>
        /// <returns></returns>
        StoreFronts AddStoreFronts(StoreFronts p_sfront);
        /// <summary>
        /// Will return List of objects related to Search query through p_name parameter
        /// </summary>
        /// <param name="p_storeNumber"></param>
        /// <returns>Filtered Search Results </returns>
        List<StoreFronts> SearchStoreFronts(int p_storeNumber);
        /// <summary>
        /// Gets All Store fronts
        /// </summary>
        /// <returns></returns>
        List<StoreFronts> GetAllStoreFronts();
        /// <summary>
        /// Gets a Comprehensive List of Stores ny ID
        /// </summary>
        /// <param name="p_store"></param>
        /// <returns></returns>
        List<StoreFronts> GetStoreHist(int p_store);
        
    }



    public interface IProductsBL
    {
        /// <summary>
        /// Adds Customer to DB passing a Customer obj
        /// </summary>
        /// <param name="p_product"></param>
        /// <returns></returns>
        Products AddProducts(Products p_product);
        /// <summary>
        /// Gets Price of Product
        /// </summary>
        /// <param name="p_productID"></param>
        /// <returns></returns>
        List<Products> GetAllProducts();
 
    }



    public interface IOrdersBL
    {
        /// <summary>
        /// Adds Order with LineItems Carts
        /// </summary>
        /// <param name="p_order"></param>
        /// <param name="_shoppingcart"></param>
        /// <returns></returns>
        Orders AddOrders(Orders p_order);
        /// <summary>
        /// Gets All Orders
        /// </summary>
        /// <returns></returns>
        List<Orders> GetAllOrders();
        /// <summary>
        /// Searches for status of Order by CustID and StoreID
        /// </summary>
        /// <param name="p_ordID"></param>
        /// <returns></returns>
        List<Orders> GetOrdersHistory(int p_custID);
        /// <summary>
        /// Gets a Single Detailed Order History
        /// </summary>
        /// <param name="p_ordID"></param>
        /// <returns></returns>
        Orders GetOrderHistory(int p_ordID);
        /// <summary>
        /// Searches Store With ID
        /// </summary>
        /// <param name="p_storeID"></param>
        /// <returns></returns>
        List<Orders> SearchStoreOrders(int p_storeID);
        /// <summary>
        /// Gets All Line Items
        /// </summary>
        /// <returns></returns>
        List<LineItems> GetAllLineItems();
        /// <summary>
        /// Add Line Items
        /// </summary>
        /// <param name="p_line"></param>
        /// <returns></returns>
        LineItems AddLineItems(LineItems p_line);
 }  



        public interface IInventoryBL
    {
        /// <summary>
        /// Adds Inventory to DB passing a Inventory obj
        /// </summary>
        /// <param name="p_inv"></param>
        /// <returns></returns>
        Inventory AddInventory(Inventory p_inv);
        /// <summary>
        /// Search Inventory by Location
        /// </summary>
        /// <param name="p_storeID"></param>
        /// <returns></returns>
        List<Inventory> SearchLocationInventory(int p_storeID);
        /// <summary>
        /// Update Inventory
        /// </summary>
        /// <param name="p_inv"></param>
        /// <returns></returns>
        Inventory UpdateInventory(Inventory p_inv);
        /// <summary>
        /// Get All Inventory
        /// </summary>
        /// <returns></returns>
        List<Inventory> GetAllInventory();

    }
}

