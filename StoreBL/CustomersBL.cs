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


        
        public Customers AddCustomers(Customers p_custs)
        {
            Console.WriteLine("Adding Customer............");
            return _repo.AddCustomers(p_custs);
        }



        public List<Customers> SearchCustomersByName(string p_fname, string p_lname)
        {
        List<Customers> listofcustomers = _repo.GetAllCustomers();
        return listofcustomers
                    .Where(Customers => Customers.CFirstName.Contains(p_fname))
                    .Where(Customers => Customers.CLastName.Contains(p_lname))
                    .ToList(); 
        }

        public List<Customers> GetAllCustomers()
        {
            List<Customers> listofcustomers = _repo.GetAllCustomers();
            return listofcustomers;
        }

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