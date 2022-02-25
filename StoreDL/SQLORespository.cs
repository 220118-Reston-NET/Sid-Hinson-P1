using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public class SQLORepository : ISQLORepository
    {

        private readonly string _ConnectionStrings;
        public SQLORepository(string p_ConnectionStrings)
        {
            _ConnectionStrings = p_ConnectionStrings;
        }


        public Orders AddOrders(Orders p_ord)
        {

            string sqlQuery1  = @"insert into Orders 
                                values (@OrderCustID, @OrderStoreID, @OrderDate, @OrderTotal, @OrderStatus)";
            string sqlQuery2 = @"insert into LineItems 
                                values (@OrderID, @ProductID, @ProductQuantity)";
            string sqlQuery3 = @"UPDATE Inventory
                                SET  ProductQuantity = ProductQuantity - @ProductQuantity
                                WHERE StoreID = @StoreID and ProductID = @ProductID";


            foreach(LineItems item in p_ord.OrderLineItems)
            {
                p_ord.OrderTotal += item.Price;
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

                //Return Highest Number of Rows to Equate Order ID
                int orderID = Convert.ToInt32(command.ExecuteScalar());


                //Add Items in Cart to LineItems DB
                foreach(LineItems item in p_ord.OrderLineItems)
                {
                    command =  new SqlCommand(sqlQuery2, con);
                    command.Parameters.AddWithValue("@OrderID", orderID);
                    command.Parameters.AddWithValue("@ProductID", item.ProductID);
                    command.Parameters.AddWithValue("@ProductQuantity", item.ProductQuantity);
                    command.ExecuteNonQuery();

                    command =  new SqlCommand(sqlQuery3, con);
                    command.Parameters.AddWithValue("@StoreID", p_ord.OrderStoreID);
                    command.Parameters.AddWithValue("@ProductID", item.ProductID);
                    command.Parameters.AddWithValue("@ProductQuantity", item.ProductQuantity);
                    command.ExecuteNonQuery();

                }

            }
            return p_ord;
        }




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
                command.Parameters.AddWithValue("@OrderStatus", p_stat.ToUpper());
                command.ExecuteNonQuery();
                Console.WriteLine("Inventory Updated");
            }
        
        }





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
                                OrderDate = reader.GetDateTime(3),
                                OrderTotal = Convert.ToDouble(reader.GetDecimal(4)),
                                OrderStatus = reader.GetString(5)
                                });
                    }
            }
            return listoforders;
        }




        public List<Orders> GetOrdersHistory(int p_ordCustID)
        {
            List<Orders> listoforders = new List<Orders>();
            string sqlQuery =@"SELECT o.OrderID, o.OrderCustID, o.OrderStoreID, o.OrderDate, o.OrderTotal, o.OrderStatus  
                                FROM Orders o 
                                WHERE o.OrderCustID = @OrderCustID";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {
                    con.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, con);
                    command.Parameters.AddWithValue("@OrderCustID", p_ordCustID);
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
            return listoforders;
        }






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

    
        public Orders GetOrderHistory(int p_ordID)
        {
            Orders orderhistory = new Orders();

            string sqlQuery =@"SELECT o.OrderID, o.OrderCustID, o.OrderStoreID, o.OrderDate, o.OrderTotal, o.OrderStatus  
                                FROM Orders o 
                                WHERE o.OrderID = @OrderID";


            string sqlQuery1 =@"SELECT OrderID, ProductID, ProductQuantity  
                                FROM LineItems li
                                WHERE OrderID = @OrderID";
            
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {
                    con.Open();


                    SqlCommand command = new SqlCommand(sqlQuery, con);
                    command.Parameters.AddWithValue("@OrderID", p_ordID);
                    SqlDataReader reader = command.ExecuteReader();
                
                    orderhistory.OrderID = reader.GetInt32(0);
                    orderhistory.OrderCustID = reader.GetInt32(1);
                    orderhistory.OrderStoreID = reader.GetInt32(2);
                    orderhistory.OrderDate = reader.GetDateTime(3);
                    orderhistory.OrderTotal = Convert.ToDouble(reader.GetDecimal(4));
                    orderhistory.OrderStatus = reader.GetString(5);
                            
                    reader.Close();
                    reader.Dispose();

                    command = new SqlCommand(sqlQuery1, con);
                    command.Parameters.AddWithValue("@OrderID", p_ordID);

                    SqlDataReader reader2 = command.ExecuteReader();
                    while(reader2.Read())
                    {

                        orderhistory.OrderLineItems.Add(new LineItems(){
                                 OrderID = reader.GetInt32(0),
                                 ProductID = reader.GetInt32(1),
                                 ProductQuantity = reader.GetInt32(2),
                                });
                    }

            }

            return orderhistory;   
        }













    }
}

