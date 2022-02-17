using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class SearchCustomersMenu : IMenu
    {
        private ICustomersBL _custBL;

        public SearchCustomersMenu(ICustomersBL p_custBL)
        {
            _custBL = p_custBL; 
        }
        public void MenuDisplay()
        {   
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("=          Menu : Search Customers         =");
            Console.WriteLine("============================================");
            Console.WriteLine("=              Select Option :             =");
            Console.WriteLine("= [0] - Exit Search                        =");
            Console.WriteLine("= [1] - Find Customer                      =");
            Console.WriteLine("============================================");
        }

        public string UserSelection()
        {
            string UserInput = Console.ReadLine();
            while(string.IsNullOrEmpty(UserInput))
            {
                Console.WriteLine("Selection must have an input. Please Enter a Menu selection.");
                UserInput =Console.ReadLine();

            }

            switch (UserInput)
            {
                case "0":
                    return "StoreMainMenu";


                case "1":
                    Console.WriteLine("Please Enter a First Name");
                    string p_Fname = Console.ReadLine();
                    p_Fname = p_Fname.ToUpper();

                    Console.WriteLine("Please Enter a Last Name");
                    string p_Lname = Console.ReadLine();
                    p_Lname = p_Lname.ToUpper();


                    Console.WriteLine("Please Enter an Email Address");
                    string p_Email = Console.ReadLine();
                    p_Email = p_Email.ToUpper();

                    //Search for Customer
                    List<Customers> listofcustomers = _custBL.SearchCustomers(p_Fname, p_Lname, p_Email);
                    if(listofcustomers.Any())
                    {
                        foreach (var Customer in listofcustomers)
                        {
                            Console.WriteLine(Customer);
                            Console.WriteLine("******************");
                            Console.WriteLine("Customer ID : " +Customer.CustomerID);
                            Console.WriteLine("******************");
                        }
                        Console.WriteLine("Press Enter");
                        Console.ReadLine();
                        return "SearchCustomersMenu";
                    }
                    else
                    {
                        //Confirm to User no result
                        Console.WriteLine("Your search did not return any results. Please try again");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        return "SearchCustomersMenu";
                    }



                default:
                    Console.WriteLine("Invalid Selection");
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "StoreMainMenu";
            }
        }
    }
}