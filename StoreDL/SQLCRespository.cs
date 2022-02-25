using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public class SQLCRepository : ISQLCRepository
    {

   
        private readonly string _ConnectionStrings;
        public SQLCRepository(string p_ConnectionStrings)
        {
            _ConnectionStrings = p_ConnectionStrings;
        }


             public Customers AddCustomers(Customers p_cust)
        {
            string sqlQuery = @"insert into Customers 
                                values (@CFirstName, @CLastName, @CDateofBirthMonth, @CDateofBirthDay, @CDateofBirthYear, @CustomerAddress, @CustomerState, @CustomerCity, @CustomerZipCode, @CustCountry, @CustomerEmail, @CPassword)";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {                        
                con.Open();
                SqlCommand command =  new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@CFirstName", p_cust.CFirstName.ToUpper());
                command.Parameters.AddWithValue("@CLastName", p_cust.CLastName.ToUpper());
                command.Parameters.AddWithValue("@CDateofBirthMonth", p_cust.CDateofBirthMonth);
                command.Parameters.AddWithValue("@CDateofBirthDay", p_cust.CDateofBirthDay);
                command.Parameters.AddWithValue("@CDateofBirthYear", p_cust.CDateofBirthYear);
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
                            CDateofBirthMonth = reader.GetInt32(3),
                            CDateofBirthDay = reader.GetInt32(4),
                            CDateofBirthYear = reader.GetInt32(5),
                            CustomerAddress = reader.GetString(6),
                            CustomerState = reader.GetString(7),
                            CustomerCity = reader.GetString(8),
                            CustomerZipcode = reader.GetString(9),
                            CustCountry = reader.GetString(10),
                            CustomerEmail = reader.GetString(11),
                            CPassword = reader.GetString(12)
                    });

                }
            }
            return listofcustomers;
        }
    }
}