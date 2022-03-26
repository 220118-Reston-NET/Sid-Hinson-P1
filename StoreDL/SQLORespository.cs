using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public class SQLoRepository : ISqloRepository
    {

        private readonly string _ConnectionStrings;
        public SQLoRepository(string p_ConnectionStrings)
        {
            _ConnectionStrings = p_ConnectionStrings;
        }
        /// <summary>
        /// Adds Orders
        /// </summary>
        /// <param name="p_ord"></param>
        /// <returns>Orders Object</returns>
        public Orders AddOrders(Orders p_ord)
        {

            string sqlQuery1  = @"insert into Orders 
                                values (@OrderCustID, @OrderStoreID, @OrderDate, @OrderTotal, @OrderStatus)";


            string sqlQuery3 = @"UPDATE Inventory
                                SET  ProductQuantity = ProductQuantity - @ProductQuantity
                                WHERE StoreID = @StoreID and ProductID = @ProductID";

            foreach(LineItems item in p_ord.OrderLineItems)
            {
                p_ord.OrderTotal += item.Price * item.ProductQuantity;
            }
            
            p_ord.OrderDate = DateTime.Now;

            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {                      
                con.Open();
                SqlCommand command =  new SqlCommand(sqlQuery1, con);
                command.Parameters.AddWithValue("@OrderCustID", p_ord.OrderCustID);
                command.Parameters.AddWithValue("@OrderStoreID", p_ord.OrderStoreID);
                command.Parameters.AddWithValue("@OrderDate", p_ord.OrderDate);
                command.Parameters.AddWithValue("@OrderTotal", p_ord.OrderTotal);
                command.Parameters.AddWithValue("@OrderStatus", p_ord.OrderStatus);
                command.ExecuteNonQuery();
                
            }

            //Find the OrderID
            List<Orders> getcount = GetAllOrders();
            p_ord.OrderID = getcount.Count();

            foreach(var item in p_ord.OrderLineItems)
            {
                item.OrderID = p_ord.OrderID;
                item.StoreID = p_ord.OrderStoreID;
                AddLineItems(item);
            }
            
            //Put LineItems in Repo
            foreach(LineItems item in p_ord.OrderLineItems)
            {

                using(SqlConnection con = new SqlConnection(_ConnectionStrings))
                {
                    //Uses LineItems in OrderLineitems to Insert Item in Inventory
                    con.Open();
                    SqlCommand command =  new SqlCommand(sqlQuery3, con);
                    command.Parameters.AddWithValue("@StoreID", item.StoreID);
                    command.Parameters.AddWithValue("@ProductID", item.ProductID);
                    command.Parameters.AddWithValue("@ProductQuantity", item.ProductQuantity);
                    command.ExecuteNonQuery();
                }
            }
                
            return p_ord;
        }



        /// <summary>
        /// Gets All Orders
        /// </summary>
        /// <returns>List of All Orders</returns>
        public List<Orders> GetAllOrders()
        {
            List<Orders> listoforders = new List<Orders>();
            string sqlQuery =@"select * from Orders ORDER BY OrderDate, OrderTotal DESC";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {
                    con.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, con);
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        listoforders.Add(new Orders(){
                                OrderID = reader.GetInt32(0),
                                OrderCustID = reader.GetInt32(1),
                                OrderStoreID = reader.GetInt32(2),
                                OrderDate = reader.GetDateTime(3),
                                OrderTotal = Convert.ToDouble(reader.GetDecimal(4)),
                                OrderStatus = reader.GetString(5)
                                });
                    }
            }
            
            foreach(Orders ord in listoforders)
            {
                ord.OrderLineItems = SearchLineItems(ord.OrderID);
            }
            return listoforders;

        }

        /// <summary>
        /// Gets Orders History
        /// </summary>
        /// <param name="p_CustID"></param>
        /// <returns>list of Orders</returns>
        public List<Orders> GetOrdersHistory(int p_CustID)
        {
            List<Orders> listoforders = new List<Orders>();
            string sqlQuery =@"SELECT o.OrderID, o.OrderCustID, o.OrderStoreID, o.OrderDate, o.OrderTotal, o.OrderStatus  
                                FROM Orders o 
                                WHERE o.OrderCustID = @OrderCustID";

            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {
                    con.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, con);
                    command.Parameters.AddWithValue("@OrderCustID", p_CustID);
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {

                        listoforders.Add(new Orders(){
                                OrderID = reader.GetInt32(0),
                                OrderCustID = reader.GetInt32(1),
                                OrderStoreID = reader.GetInt32(2),
                                OrderDate = reader.GetDateTime(3),
                                OrderTotal = Convert.ToDouble(reader.GetDecimal(4)),
                                OrderStatus = reader.GetString(5),
                                });
                    }
            }
            foreach(Orders ord in listoforders)
            {
                ord.OrderLineItems = SearchLineItems(ord.OrderID);
            }
            return listoforders;
        }
        /// <summary>
        /// Gets Order History
        /// </summary>
        /// <param name="p_ordID"></param>
        /// <returns></returns>
        public Orders GetOrderHistory(int p_ordID)
        {
            Orders orderhistory = new Orders();

            string sqlQuery =@"SELECT o.OrderID, o.OrderCustID, o.OrderStoreID, o.OrderDate, o.OrderTotal, o.OrderStatus  
                                FROM Orders o 
                                WHERE o.OrderID = @OrderID";


            string sqlQuery1 =@"SELECT OrderID, ProductID, ProductQuantity, Price, StoreID  
                                FROM LineItems li
                                WHERE OrderID = @OrderID";
            
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {
                    con.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, con);
                    command.Parameters.AddWithValue("@OrderID", p_ordID);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    orderhistory.OrderID = reader.GetInt32(0);
                    orderhistory.OrderCustID = reader.GetInt32(1);
                    orderhistory.OrderStoreID = reader.GetInt32(2);
                    orderhistory.OrderDate = reader.GetDateTime(3);
                    orderhistory.OrderTotal = Convert.ToDouble(reader.GetDecimal(4));
                    orderhistory.OrderStatus = reader.GetString(5);
                    
            }

            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery1, con);
                command.Parameters.AddWithValue("@OrderID", p_ordID);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {

                    orderhistory.OrderLineItems.Add(new LineItems(){
                                OrderID = reader.GetInt32(0),
                                ProductID = reader.GetInt32(1),
                                ProductQuantity = reader.GetInt32(2),
                                Price = Convert.ToDouble(reader.GetDecimal(3)),
                                StoreID = reader.GetInt32(4),
                            });
                }
            }
            
            return orderhistory;   
        }
        /// <summary>
        /// Gets All LineItems
        /// </summary>
        /// <returns>List of LineItems</returns>
        public List<LineItems> GetAllLineItems()
        {
            List<LineItems> listoflineitems = new List<LineItems>();
            string sqlQuery =@"select * from LineItems";

                using(SqlConnection con = new SqlConnection(_ConnectionStrings))
                {

                    con.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, con);
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {

                        listoflineitems.Add(new LineItems(){
                                OrderID = reader.GetInt32(0),
                                ProductID = reader.GetInt32(1),
                                ProductQuantity = reader.GetInt32(2),
                                Price = Convert.ToDouble(reader.GetDecimal(3)),
                                StoreID = reader.GetInt32(4)
                                });
                    }
                }
            return listoflineitems;
        }  
        /// <summary>
        /// Adds LineItems
        /// </summary>
        /// <param name="p_line"></param>
        /// <returns></returns>
        public LineItems AddLineItems(LineItems p_line)
        {
            string sqlQuery = @"insert into LineItems 
                                values (@OrderID, @ProductID, @ProductQuantity, @Price, @StoreID)";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {                      
                con.Open();
                SqlCommand command =  new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@OrderID", p_line.OrderID);
                command.Parameters.AddWithValue("@ProductID",p_line.ProductID);
                command.Parameters.AddWithValue("@ProductQuantity",p_line.ProductQuantity);
                command.Parameters.AddWithValue("@Price",p_line.Price);
                command.Parameters.AddWithValue("@StoreID",p_line.StoreID);
                command.ExecuteNonQuery();

            }
            return p_line;
        }

        public List<LineItems> SearchLineItems(int p_ordID)
        {
             List<LineItems> lineItemsOrderID = GetAllLineItems()
                                .Where(lineitem => lineitem.OrderID.Equals(p_ordID))
                                .ToList();
            return lineItemsOrderID;
        }

         /// <summary>
        /// Add Inventory
        /// </summary>
        /// <param name="p_inv"></param>
        /// <returns></returns>
        public Inventory AddInventory(Inventory p_inv)
        {
            string sqlQuery = @"insert into Inventory 
                                values (@StoreID, @ProductID, @ProductQuantity)";

            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {          
                con.Open();
                SqlCommand command =  new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@StoreID", p_inv.StoreID);
                command.Parameters.AddWithValue("@ProductID", p_inv.ProductID);
                command.Parameters.AddWithValue("@ProductQuantity", p_inv.ProductQuantity);
                command.ExecuteNonQuery();
            }
            return p_inv;
        }
        /// <summary>
        /// Gets All Inventory
        /// </summary>
        /// <returns></returns>
        public List<Inventory> GetAllInventory()
        {
            List<Inventory> listofinventory = new List<Inventory>();
            string sqlQuery =@"select * from Inventory";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    listofinventory.Add(new Inventory(){
                            WarehouseID = reader.GetInt32(0),
                            StoreID = reader.GetInt32(1),
                            ProductID= reader.GetInt32(2),
                            ProductQuantity = reader.GetInt32(3),
                    });
                }
            }
            return listofinventory;
        }
        /// <summary>
        /// Updates Inventory
        /// </summary>
        /// <param name="p_inv"></param>
        /// <returns>Inventory Object</returns>
        public Inventory UpdateInventory(Inventory p_inv)
        {
            Console.WriteLine("Attempting to Update Inventory...............");
            string sqlQuery = @"UPDATE Inventory
                                SET  ProductQuantity = @ProductQuantity
                                WHERE StoreID = @StoreID and ProductID = @ProductID";


            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {          
                con.Open();
                SqlCommand command =  new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@StoreID", p_inv.StoreID);
                command.Parameters.AddWithValue("@ProductID", p_inv.ProductID);
                command.Parameters.AddWithValue("@ProductQuantity", p_inv.ProductQuantity);
                command.ExecuteNonQuery();
                Console.WriteLine("Inventory Updated");
            }
            return p_inv;
        }
    }
    
}

