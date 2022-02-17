// using StoreModel;

// namespace StoreDL
// {
//     /// <summary>
//     /// Data Layer Interface - DB - CRUD
//     /// </summary>

//     //////////////////////JSON DEPRECATION BELOW HERE/////////////////////////////////////////

//     /// <summary>
//     /// Customers Interface
//     /// </summary>
//     /// 
//     public interface ICustomersRepo
//     {
//         /// <summary>
//         /// Add Customers to DB
//         /// </summary>
//         /// <param name="p_cust"></param> Customer Object
//         /// <returns>Customer Added</returns>
//         Customers AddCustomers(Customers p_cust);
//         /// <summary>
//         /// Will Get All Customers in DB
//         /// </summary>
//         /// <returns>Returns List</returns>
//         List<Customers> GetAllCustomers();
//     }


//        /// <summary>
//        /// Store Fronts Interface
//        /// </summary>
//     public interface IStoreFrontsRepo
//     {
//         /// <summary>
//         /// Add StoreFronts to DB
//         /// </summary>
//         /// <param name="p_front"></param> Customer Object
//         /// <returns>Returns StoreFront Added</returns>
//         StoreFronts AddStoreFronts(StoreFronts p_front);
//         /// <summary>
//         /// Will Get All StoreFronts in DB
//         /// </summary>
//         /// <returns>Returns StoreFront Lists</returns>
//         List<StoreFronts> GetAllStoreFronts();
//     }
//        /// <summary>
//        /// Products Interface
//        /// </summary>
//     public interface IProductsRepo
//     {
//         /// <summary>
//         /// Add Products to DB
//         /// </summary>
//         /// <param name="p_product"></param> Customer Object
//         /// <returns>Returns Products Added</returns>
//         Products AddProducts(Products p_product);
//         /// <summary>
//         /// Will Get All Products in DB
//         /// </summary>
//         /// <returns>Returns Products List</returns>
//         List<Products> GetAllProducts();
//     }
//        /// <summary>
//        /// Orders Interface
//        /// </summary>
//     public interface IOrdersRepo
//     {
//         /// <summary>
//         /// Add Orders
//         /// </summary>
//         /// <param name="p_order"></param>
//         /// <returns>returns Order</returns>
//         Orders AddOrders(Orders p_order);
//         /// <summary>
//         /// Adds Orders to Order History
//         /// </summary>
//         /// <param name="p_order"></param>
//         /// <returns></returns>
//         // Orders AddOrdersHistory(Orders p_order);
//         // /// <summary>
//         // /// Returns All Orders
//         // /// </summary>
//         // /// <returns>List of Orders</returns>
//         List<Orders> GetAllOrders();

//     }


// }
