using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public class SqlcRepository : ISqlcRepository
    {

   
        private readonly string _ConnectionStrings;
        public SqlcRepository(string p_ConnectionStrings)
        {
            _ConnectionStrings = p_ConnectionStrings;
        }


             public Customers AddCustomers(Customers p_cust)
        {
            string sqlQuery = @"insert into Customers 
                                values (@CFirstName, @CLastName, @CustomerAddress, @CustomerState, @CustomerCity, @CustomerZipCode, @CustCountry, @CustomerEmail, @CPassword, @isAdmin)";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {                        
                con.Open();
                SqlCommand command =  new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@CFirstName", p_cust.CFirstName.ToUpper());
                command.Parameters.AddWithValue("@CLastName", p_cust.CLastName.ToUpper());
                command.Parameters.AddWithValue("@CustomerAddress", p_cust.CustomerAddress.ToUpper());
                command.Parameters.AddWithValue("@CustomerState", p_cust.CustomerState.ToUpper());
                command.Parameters.AddWithValue("@CustomerCity", p_cust.CustomerCity.ToUpper());
                command.Parameters.AddWithValue("@CustomerZipCode", p_cust.CustomerZipcode.ToUpper());
                command.Parameters.AddWithValue("@CustCountry", p_cust.CustomerCountry.ToUpper());
                command.Parameters.AddWithValue("@CustomerEmail",p_cust.CustomerEmail.ToUpper());
                command.Parameters.AddWithValue("@CPassword", p_cust.CPassword);
                command.Parameters.AddWithValue("@isAdmin", p_cust.isAdmin);
                command.ExecuteNonQuery();
            }
            return p_cust;
        }



        public List<Customers> GetAllCustomers()
        {
            List<Customers> listofcustomers = new List<Customers>();
            string sqlQuery =@"select * from Customers";
             using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    listofcustomers.Add(new Customers(){
                            CustomerID = reader.GetInt32(0),
                            CFirstName = reader.GetString(1),
                            CLastName = reader.GetString(2),
                            CustomerAddress = reader.GetString(3),
                            CustomerState = reader.GetString(4),
                            CustomerCity = reader.GetString(5),
                            CustomerZipcode = reader.GetString(6),
                            CustomerCountry = reader.GetString(7),
                            CustomerEmail = reader.GetString(8),
                            CPassword = reader.GetString(9),
                            isAdmin = reader.GetBoolean(10)
                    });

                }
            }
            return listofcustomers;
        }
    }
}