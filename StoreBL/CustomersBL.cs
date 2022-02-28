using StoreModel;
using StoreDL;

namespace StoreBL
{

    public class CustomersBL : ICustomersBL
    {
        private ISQLCRepository _repo;
        public CustomersBL(ISQLCRepository p_repo)
        {
            _repo = p_repo;
        }


        
        public Customers AddCustomers(Customers p_cust)
        {
            List<Customers> listofcustomers = _repo.GetAllCustomers();
            Console.WriteLine("Adding Customer............");
            return _repo.AddCustomers(p_cust);
        }



        public List<Customers> SearchCustomersByName(string p_fname, string p_lname)
        {
        List<Customers> listofcustomers = _repo.GetAllCustomers();
        return listofcustomers
                    .Where(Customers => Customers.CFirstName.Contains(p_fname))
                    .Where(Customers => Customers.CLastName.Contains(p_lname))
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

        public bool isAdmin(string p_email, string p_pass)
        {
            bool isAdmin = false;
            List<Customers> listofcustomers = _repo.GetAllCustomers();
            for(int i = 0; i < listofcustomers.Count; i++)
            {
                if(listofcustomers[i].CustomerEmail.Contains(p_email) & listofcustomers[i].CPassword.Contains(p_pass))
                {
                    if(listofcustomers[i].isAdmin == true)
                    {
                        isAdmin = true;
                    }
                    else
                    {
                        isAdmin = false;
                    }
                }
            }
            return isAdmin;
        }




    }
}