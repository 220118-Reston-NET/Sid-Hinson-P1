using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public class SQL_CRepository : ISQL_CRepository
    {

   
        private readonly string _ConnectionStrings;
        public SQL_CRepository(string p_ConnectionStrings)
        {
            _ConnectionStrings = p_ConnectionStrings;
        }


             public Customers AddCustomers(Customers p_cust)
        {
            string sqlQuery = @"insert into Customers 
                                values (@CFirstName, @CLastName, @CDateofBirth, @CustomerAddress, @CustomerState, @CustomerCity, @CustomerZipCode, @CustCountry, @CustomerEmail, @CPassword)";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {                        
                con.Open();
                SqlCommand command =  new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@CFirstName", p_cust.CFirstName.ToUpper());
                command.Parameters.AddWithValue("@CLastName", p_cust.CLastName.ToUpper());
                command.Parameters.AddWithValue("@CDateofBirth", p_cust.CDateofBirth.ToUpper());
                command.Parameters.AddWithValue("@CustomerAddress", p_cust.CustomerAddress.ToUpper());
                command.Parameters.AddWithValue("@CustomerState", p_cust.CustomerState.ToUpper());
                command.Parameters.AddWithValue("@CustomerCity", p_cust.CustomerCity.ToUpper());
                command.Parameters.AddWithValue("@CustomerZipCode", p_cust.CustomerZipcode.ToUpper());
                command.Parameters.AddWithValue("@CustCountry", p_cust.CustCountry.ToUpper());
                command.Parameters.AddWithValue("@CustomerEmail",p_cust.CustomerEmail.ToUpper());
                command.Parameters.AddWithValue("@CPassword", p_cust.CPassword);
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
                            CDateofBirth = reader.GetString(3),
                            CustomerAddress = reader.GetString(4),
                            CustomerState = reader.GetString(5),
                            CustomerCity = reader.GetString(6),
                            CustomerZipcode = reader.GetString(7),
                            CustCountry = reader.GetString(8),
                            CustomerEmail = reader.GetString(9),
                            CPassword = reader.GetString(10)
                    });

                }
            }
            return listofcustomers;
        }
    }
}