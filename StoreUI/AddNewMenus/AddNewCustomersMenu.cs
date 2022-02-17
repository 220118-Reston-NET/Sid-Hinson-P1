using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class NewCustomersMenu : IMenu
    {
        //Static Class for variable Consistently Across the Created Class Objects
        private static Customers _newCustomer = new Customers();
        //Dependency Injection
        private ICustomersBL _custBL;
        //
        public NewCustomersMenu(ICustomersBL p_custBL)
        {
            _custBL = p_custBL;
        }


        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=             Menu : Add Customer              =");
            Console.WriteLine("===============================================");
            Console.WriteLine("=       Enter New Customer Info : Select       =");
            Console.WriteLine("=       (Initial Values Are For Example)       =");
            Console.WriteLine("================================================");
            Console.WriteLine("=[0]  -  Return to Main Menu"); 
            Console.WriteLine("=[1]  -  First Name : " + _newCustomer.CFirstName); 
            Console.WriteLine("=[2]  -  Last Name : " + _newCustomer.CLastName); 
            Console.WriteLine("=[3]  -  Address : " + _newCustomer.CustomerAddress);
            Console.WriteLine("=[4]  -  City : " + _newCustomer.CustomerCity);        
            Console.WriteLine("=[5]  -  State : " + _newCustomer.CustomerState);
            Console.WriteLine("=[6]  -  Country : " + _newCustomer.CustCountry);
            Console.WriteLine("=[7]  -  Zipcode : " + _newCustomer.CustomerZipcode);
            Console.WriteLine("=[8]  -  Email : " + _newCustomer.CustomerEmail);
            Console.WriteLine("=[9]  -  Date Of Birth : " + _newCustomer.CDateofBirth);
            Console.WriteLine("=[10] -  Password : " + _newCustomer.CPassword);
            Console.WriteLine("=[11] -  Update & Save Information");
            Console.WriteLine("===============================================");
            Console.WriteLine("=!Press Number + Enter to input Selected Info!=");
            Console.WriteLine("===============================================");
        }
        
        public string UserSelection()
        {   Log.Information("User is inputting a selection");
            string userInput = Console.ReadLine();
            switch (userInput)
            {

                //Exit
                case "0":
                    Log.Information("User is exiting to Store Main Menu");
                    return "StoreMainMenu";


                //First Name Input
                case "1":
                    Log.Information("User is entering a First Name");
                    Console.WriteLine("Enter your First Name :");
                    _newCustomer.CFirstName = Console.ReadLine();
                    _newCustomer.CFirstName = _newCustomer.CFirstName.ToUpper();
                    return "NewCustomersMenu";


                //Last Name Input
                case "2":
                    Log.Information("User is entering a Last Name");
                    Console.WriteLine("Enter your Last Name : ");
                    _newCustomer.CLastName = Console.ReadLine();
                    _newCustomer.CLastName = _newCustomer.CLastName.ToUpper();
                    return "NewCustomersMenu";


                // Address Input
                case "3":
                    Log.Information("User is entering their Address");
                    Console.WriteLine("Enter your Address : ");
                    _newCustomer.CustomerAddress = Console.ReadLine();
                    _newCustomer.CustomerAddress = _newCustomer.CustomerAddress.ToUpper();
                    return "NewCustomersMenu";


                // City Input
                case "4":
                    Log.Information("User is entering their City");
                    Console.WriteLine("Enter your City :");
                    _newCustomer.CustomerCity = Console.ReadLine();
                    _newCustomer.CustomerCity = _newCustomer.CustomerCity.ToUpper();
                    return "NewCustomersMenu";


                // State Input
                case "5":
                    Log.Information("User is entering their State");
                    Console.WriteLine("Enter your State Abbreviation:");
                    _newCustomer.CustomerState = Console.ReadLine();
                    _newCustomer.CustomerState = _newCustomer.CustomerState.ToUpper();
                    return "NewCustomersMenu";


                // Country Input
                case "6":
                    Log.Information("User is entering their Country");
                    Console.WriteLine("Enter your Country :");
                    _newCustomer.CustCountry = Console.ReadLine();
                    _newCustomer.CustCountry = _newCustomer.CustCountry.ToUpper();
                    return "NewCustomersMenu";


                // Zip Code Input
                case "7":
                    Log.Information("User is entering their Zipcode");
                    Console.WriteLine("Enter your Zipcode :");
                    _newCustomer.CustomerZipcode = Console.ReadLine();
                    return "NewCustomersMenu";


                // Email Input
                case "8":
                    Log.Information("User is entering their Email Address");
                    Console.WriteLine("Enter your Email Address :");
                    _newCustomer.CustomerEmail = Console.ReadLine();
                    _newCustomer.CustomerEmail = _newCustomer.CustomerEmail.ToUpper();
                    return "NewCustomersMenu";


                // Date of Birth Entry
                case "9":
                    Log.Information("User is entering their Date of Birth");
                    Console.WriteLine("Enter your Date of Birth");
                    Console.WriteLine("Example : 10211980 for October 21st 1980");
                    _newCustomer.CDateofBirth = Console.ReadLine();
                    return "NewCustomersMenu";

                // Password Entry
                case "10":
                    Log.Information("User is entering their Password");
                    Console.WriteLine("Enter your Password");
                    Console.WriteLine("A combination of Letters and charcter is more secure - ex: [@#$]@@!!^&*");
                    _newCustomer.CPassword = Console.ReadLine();
                    return "NewCustomersMenu";     

                //**Save to DB Repo
                case "11":
                    Log.Information("User is attempting to Save their Customer Information into the DB");
                    try
                    {   
                        _custBL.AddCustomers(_newCustomer);

                    }
                    catch (System.Exception exc)
                    {
                        Log.Information("User has attempted to save and the program has created an exception");
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Something Unexpected Happened");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    return "NewCustomersMenu";


                    default:
                    Log.Information("User has made an Invalid Selection");
                    Console.WriteLine("You have made an Invalid Selection - Please Press Enter to Continue");
                    Console.ReadLine();
                    return "NewCustomersMenu";
            }
        }
    }
}