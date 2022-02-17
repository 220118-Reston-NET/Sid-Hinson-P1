using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public class SQL_PRepository : ISQL_PRepository
    {

        private readonly string _ConnectionStrings;
        public SQL_PRepository(string p_ConnectionStrings)
        {
            _ConnectionStrings = p_ConnectionStrings;
        }

        public Products AddProducts(Products p_prod)
        {
            
 
            string sqlQuery = @"insert into Products 
                                values (@StoreID,@ProductName, @ProductCompany, @ProductPrice, @ProductDescription, @ProductCategory)";


            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {          
                con.Open();
                SqlCommand command =  new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@StoreID", p_prod.StoreID);
                command.Parameters.AddWithValue("@ProductName", p_prod.ProductName);
                command.Parameters.AddWithValue("@ProductCompany", p_prod.ProductCompany);
                command.Parameters.AddWithValue("@ProductPrice", p_prod.ProductPrice);
                command.Parameters.AddWithValue("@ProductDescription", p_prod.ProductDescription);
                command.Parameters.AddWithValue("@ProductCategory", p_prod.ProductCategory);
                command.ExecuteNonQuery();
            }
            return p_prod;
        }
        public List<Products> GetAllProducts()
        {
            List<Products> listofproducts = new List<Products>();
            string sqlQuery =@"select * from Products";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {

                    listofproducts.Add(new Products(){
                            ProductID = reader.GetInt32(0),
                            StoreID = reader.GetInt32(1),
                            ProductName = reader.GetString(2),
                            ProductCompany = reader.GetString(3),
                            ProductPrice = Decimal.ToInt32(reader.GetDecimal(4)),
                            ProductDescription = reader.GetString(5),
                            ProductCategory = reader.GetString(6),
                    });
                }
            }
            return listofproducts;
        }
    }
}