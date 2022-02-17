using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public class SQL_ORepository : ISQL_ORepository
    {


        private readonly string _ConnectionStrings;
        public SQL_ORepository(string p_ConnectionStrings)
        {
            _ConnectionStrings = p_ConnectionStrings;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_ord"></param>
        /// <returns></returns>
        public Orders AddOrders(Orders p_ord)
        {
            string sqlQuery = @"insert into Orders 
                                values (@OrderCustID, @OrderStoreID, @OrderDate, @OrderTotal, @OrderStatus)";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {                      
                con.Open();
                SqlCommand command =  new SqlCommand(sqlQuery, con);


                command.Parameters.AddWithValue("@OrderCustID", p_ord.OrderCustID);
                command.Parameters.AddWithValue("@OrderStoreID", p_ord.OrderStoreID);
                command.Parameters.AddWithValue("@OrderDate", p_ord.OrderDate);
                command.Parameters.AddWithValue("@OrderTotal", p_ord.OrderTotal);
                command.Parameters.AddWithValue("@OrderStatus", p_ord.OrderStatus);
 
                //EXECUTES THE SQL Statement
                command.ExecuteNonQuery();
            }
            return p_ord;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_ordID"></param>
        /// <param name="p_stat"></param>
        public void UpdateOrdStat(int p_ordID, string p_stat)
        {
            Console.WriteLine("Changing Order Status");
            string sqlQuery = @"UPDATE Orders
                                SET  OrderStatus = @OrderStatus
                                WHERE OrderID = @OrderID";


            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {          
                con.Open();
                SqlCommand command =  new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@OrderID", p_ordID);
                command.Parameters.AddWithValue("@OrderStatus", p_stat);
                command.ExecuteNonQuery();
                Console.WriteLine("Inventory Updated");
            }
        
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_line"></param>
        /// <returns></returns>
        public LineItems AddLineItems(LineItems p_line)
        {
            string sqlQuery = @"insert into LineItems 
                                values (@OrderID, @ProductID, @ProductQuantity)";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {                      
                con.Open();
                SqlCommand command =  new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@OrderID", p_line.OrderID);
                command.Parameters.AddWithValue("@ProductID",p_line.ProductID);
                command.Parameters.AddWithValue("@ProductQuantity",p_line.ProductQuantity);
                command.ExecuteNonQuery();

            }
            return p_line;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Orders> GetAllOrders()
        {
            List<Orders> listoforders = new List<Orders>();
            string sqlQuery =@"select * from Orders";
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
                                OrderDate = reader.GetString(3),
                                OrderTotal = Convert.ToDouble(reader.GetDecimal(4)),
                                OrderStatus = reader.GetString(5)
                                });
                    }
            }
            return listoforders;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Orders> GetCompOrderHist(int p_custID)
        {

            List<Orders> listoforders = new List<Orders>();
            string sqlQuery =@"SELECT o.OrderID, o.OrderCustID, o.OrderStoreID, o.OrderDate, o.OrderTotal, o.OrderStatus, li.ProductID, li.ProductQuantity, p.ProductName, c.CLastName   
                                FROM Orders o 
                                INNER JOIN Customers c ON c.CustomerID = o.OrderCustID 
                                INNER JOIN LineItems li ON li.OrderID = o.OrderID
                                INNER JOIN Products p ON p.ProductID = li.ProductID 
                                WHERE o.OrderCustID = @OrderID";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {
                    con.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, con);
                    command.Parameters.AddWithValue("@OrderID", p_custID);
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {

                        listoforders.Add(new Orders(){
                                OrderID = reader.GetInt32(0),
                                OrderCustID = reader.GetInt32(1),
                                OrderStoreID = reader.GetInt32(2),
                                OrderDate = reader.GetString(3),
                                OrderTotal = Convert.ToDouble(reader.GetDecimal(4)),
                                OrderStatus = reader.GetString(5),
                                ProductID = reader.GetInt32(6),
                                ProductQuantity = reader.GetInt32(7),
                                ProductName = reader.GetString(8),
                                CLastName = reader.GetString(9),
                                });
                    }
            }
            return listoforders;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
                                });
                    }
                }
            return listoflineitems;
        }  
    }
}

