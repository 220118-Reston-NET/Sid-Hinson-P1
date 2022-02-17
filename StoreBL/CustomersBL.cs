using StoreModel;
using StoreDL;

namespace StoreBL
{

    public class CustomersBL : ICustomersBL
    {
        private ISQL_CRepository _repo;
        public CustomersBL(ISQL_CRepository p_repo)
        {
            _repo = p_repo;
        }
        public Customers AddCustomers(Customers p_cust)
        {
            List<Customers> listofcustomers = _repo.GetAllCustomers();
            Console.WriteLine("Adding Customer............");
            return _repo.AddCustomers(p_cust);
        }

        public List<Customers> SearchCustomers(string p_fname, string p_lname, string p_email)
        {
        List<Customers> listofcustomers = _repo.GetAllCustomers();
        return listofcustomers
                    .Where(Customers => Customers.CFirstName.Contains(p_fname))
                    .Where(Customers => Customers.CLastName.Contains(p_lname))
                    .Where(Customers => Customers.CustomerEmail.Contains(p_email))
                    .ToList(); 
        }

        public List<Customers> SearchForCustomers(string p_fname, string p_lname, string p_city, string p_state)
        {
            List<Customers> listofcustomers = _repo.GetAllCustomers();
            return listofcustomers
                    .Where(Customers => Customers.CFirstName.Contains(p_fname))
                    .Where(Customers => Customers.CLastName.Contains(p_lname))
                    .Where(Customers => Customers.CustomerCity.Contains(p_city))
                    .Where(Customers => Customers.CustomerState.Contains(p_state))
                    .ToList();
        }

        public int GetID(string p_email, string p_pass)
        {   
            int CustomerID = 0;
            List<Customers> listofcustomers = _repo.GetAllCustomers();
            for(int i = 0; i < listofcustomers.Count; i++)
            {
                if(listofcustomers[i].CustomerEmail.Contains(p_email) & listofcustomers[i].CPassword.Contains(p_pass))
                {
                    CustomerID = listofcustomers[i].CustomerID;    
                }
            }
            return CustomerID;
        }
        public List<Customers> GetAllCustomers()
        {
            List<Customers> listofcustomers = _repo.GetAllCustomers();
            return listofcustomers;
        }
    }
}