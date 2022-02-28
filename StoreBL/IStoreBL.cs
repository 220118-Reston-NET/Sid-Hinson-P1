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
        int GetID(string p_email, string p_pass);
        /// <summary>
        /// Gets All Custoemrs
        /// </summary>
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
        /// Finds Product By Name and Store ID
        /// </summary>
        /// <param name="p_productName"></param>
        /// <param name="p_productStoreID"></param>
        /// <returns></returns>
        Products SearchForProduct(string p_productName, int p_productStoreID);
        /// <summary>
        /// Gets Price of Product
        /// </summary>
        /// <param name="p_productID"></param>
        /// <returns></returns>
        double GetPrice(int p_productID);
        /// <summary>
        /// Gets ID of a Product
        /// </summary>
        /// <param name="p_prodName"></param>
        /// <param name="p_prodComp"></param>
        /// <param name="p_StoreID"></param>
        /// <returns></returns>
        int GetID(string p_prodName, string p_prodComp, int p_StoreID);
        /// <summary>
        /// Gets All products
        /// </summary>
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
        /// Will return List of objects related to Search query through p_name parameter
        /// </summary>
        /// <param name="p_order"></param>
        /// <returns>Filtered Search Results </returns>
        // List<Orders> SearchOrders(string p_email);
        List<Orders> SearchOrders(int p_custID, string p_status);
        /// <summary>
        /// Searches for order
        /// </summary>
        /// <param name="p_custID"></param>
        /// <param name="p_storeID"></param>
        /// <returns></returns>
        List<Orders> SearchForOrderbyID(int p_custID, int p_storeID);
        /// <summary>
        /// Searches for status of Order by CustID and StoreID
        /// </summary>
        /// <param name="p_ordID"></param>
        /// <returns></returns>
        Orders SearchOrdStat(int p_ordID);
        /// <summary>
        /// Updates the Status Qualifier of an Order
        /// </summary>
        /// <param name="p_ordID"></param>
        /// <param name="p_stat"></param>
        void UpdateOrdStat(int p_ordID, string p_stat);
        /// <summary>
        /// Gets a comprehensive Order History
        /// </summary>
        /// <param name="p_custID"></param>
        /// <returns></returns>
        List<Orders> GetOrdersHistory(int p_custID);
        /// <summary>
        /// Gets a Single Detailed Order History
        /// </summary>
        /// <param name="p_ordID"></param>
        /// <returns></returns>
        Orders GetOrderHistory(int p_ordID);
        /// <summary>
        /// Add Line Items to Repo
        /// </summary>
        /// <param name="p_line"></param>
        /// <returns>linetime</returns>
        LineItems AddLineItems(LineItems p_line);
        /// <summary>
        /// SearchOrdersByStore
        /// </summary>
        /// <param name="p_storeID"></param>
        /// <returns></returns>
        List<Orders> SearchStoreOrders(int p_storeID);
        /// <summary>
        /// Adds Items to a LineItem
        /// </summary>
        /// <param name="p_prodID"></param>
        /// <param name="p_prodQuant"></param>
        /// <param name="p_storeID"></param>
        /// <param name="p_price"></param>
        /// <returns></returns>
        List<LineItems> SearchLineItems(int p_orderID);
        /// <summary>
        /// Displays Cart
        /// </summary>
        /// <param name="p_list"></param>
        /// <returns></returns>
        LineItems AddItemFields(int p_prodID, int p_prodQuant, int p_storeID, double p_price);
        /// <summary>
        /// Searches Line Items
        /// </summary>
        /// <param name="p_orderID"></param>
        /// <returns></returns>
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
        /// Finds the Par Level of Inventory
        /// </summary>
        /// <param name="p_storeID"></param>
        /// <param name="p_prodname"></param>
        /// <returns></returns>
        Inventory FindItemLevel(int p_storeID, int p_prodID);
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

