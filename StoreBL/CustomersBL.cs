using StoreModel;
using StoreDL;
using System.Data.SqlClient;

namespace StoreBL
{

    public class CustomersBL : ICustomersBL
    {
        private readonly ISqlcRepository _repo;
        public CustomersBL(ISqlcRepository p_repo)
        {
            _repo = p_repo;
        }


        /// <summary>
        /// Adds Customers
        /// </summary>
        /// <param name="p_custs"></param>
        /// <returns>p_custs object</returns>
        public Customers AddCustomers(Customers p_custs)
        {
            Console.WriteLine("Adding Customer............");
            return _repo.AddCustomers(p_custs);
        }


        /// <summary>
        /// Searches Customers by First and Last Name
        /// </summary>
        /// <param name="p_fname"></param>
        /// <param name="p_lname"></param>
        /// <returns>a list</returns>
        public List<Customers> SearchCustomersByName(string p_fname, string p_lname)
        {
        List<Customers> listofcustomers = _repo.GetAllCustomers();
        return listofcustomers
                    .Where(Customers => Customers.CFirstName.Contains(p_fname))
                    .Where(Customers => Customers.CLastName.Contains(p_lname))
                    .ToList(); 
        }
        /// <summary>
        /// Gtes All Customers
        /// </summary>
        /// <returns>A list</returns>
        public List<Customers> GetAllCustomers()
        {
            List<Customers> listofcustomers = _repo.GetAllCustomers();
            return listofcustomers;
        }
        /// <summary>
        /// Boolean returns True if Customer isAdmin
        /// </summary>
        /// <param name="p_email"></param>
        /// <param name="p_pass"></param>
        /// <returns></returns>
        public bool isAdmin(string p_email, string p_pass)
        {
            try
            {
                // Customers cust = new Customers();
                // Customers cust = GetAllCustomers().Where(cust => cust.CustomerEmail.Equals(p_email) && cust.CPassword.Equals(p_pass)).First();
                Customers cust = GetAllCustomers().First(cust => cust.CustomerEmail.Equals(p_email) && cust.CPassword.Equals(p_pass));
                return cust.isAdmin;
            }
            catch(SqlException)
            {
                throw new NullReferenceException();
            }
        }


    }
}