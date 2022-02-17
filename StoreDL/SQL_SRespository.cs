using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public class SQL_SRepository : ISQL_SRepository
    {
        private readonly string _ConnectionStrings;
        public SQL_SRepository(string p_ConnectionStrings)
        {
            _ConnectionStrings = p_ConnectionStrings;
        }

        public StoreFronts AddStoreFronts(StoreFronts p_store)
        {

            string sqlQuery = @"insert into StoreFronts 
                                values (@StoreAddress, @StoreZipCode, @StoreState, @StoreCity)";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {                                    
                con.Open();
                SqlCommand command =  new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@StoreAddress", p_store.StoreAddress);
                command.Parameters.AddWithValue("@StoreZipCode", p_store.StoreZipCode);
                command.Parameters.AddWithValue("@StoreState", p_store.StoreState);
                command.Parameters.AddWithValue("@StoreCity", p_store.StoreCity);
                command.ExecuteNonQuery();
            }
            return p_store;
        }

        public List<StoreFronts> GetAllStoreFronts()
        {
            List<StoreFronts> listofstorefronts = new List<StoreFronts>();
            string sqlQuery =@"select * from StoreFronts";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    listofstorefronts.Add(new StoreFronts(){
                            StoreID = reader.GetInt32(0),
                            StoreAddress = reader.GetString(1),
                            StoreZipCode = reader.GetString(2),
                            StoreState = reader.GetString(3),
                            StoreCity = reader.GetString(4),
                    });
                }
            }
            return listofstorefronts;
        }

        public List<StoreFronts> GetCompStoreHist(int p_store)
        {
            List<StoreFronts> listofstorefronts = new List<StoreFronts>();
            string sqlQuery =@"SELECT sf.StoreID , sf.StoreAddress, sf.StoreZipCode, sf.StoreState, sf.StoreCity, o.OrderID, o.OrderDate, o.OrderTotal, o.OrderStatus, c.CustomerID, c.CLastName  
                                FROM StoreFronts sf 
                                INNER JOIN Orders o ON sf.StoreID = o.OrderStoreID 
                                INNER JOIN Customers c ON o.OrderCustID = c.CustomerID 
                                WHERE sf.StoreID = @StoreID";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@StoreID", p_store);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    listofstorefronts.Add(new StoreFronts(){
                            StoreID = reader.GetInt32(0),
                            StoreAddress = reader.GetString(1),
                            StoreZipCode = reader.GetString(2),
                            StoreState = reader.GetString(3),
                            StoreCity = reader.GetString(4),
                            OrderID = reader.GetInt32(5),
                            OrderDate = reader.GetString(6),
                            OrderTotal = Convert.ToDouble(reader.GetDecimal(7)),
                            OrderStatus = reader.GetString(8),
                            CustID = reader.GetInt32(9),
                            CLastName = reader.GetString(10),
                
                    });
                }
            }
            return listofstorefronts; 
        }
    }
}