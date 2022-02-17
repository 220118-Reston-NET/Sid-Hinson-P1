using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class CustomersMenu : IMenu
    {

        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
            Console.WriteLine(" ***All NEW Customers Must Register / SHOP NOW to Order** ");
            Console.WriteLine("==========================================================");
            Console.WriteLine("=                     Customer Menu                      =");
            Console.WriteLine("==========================================================");
            Console.WriteLine("=              Enter Number to Select Option             =");     
            Console.WriteLine("==========================================================");
            Console.WriteLine("=          [0] - Return to Main Menu / Exit              =");
            Console.WriteLine("=          [1] - Register Customer Information           =");
            Console.WriteLine("=          [2] - Find Your Customer ID                   =");
            Console.WriteLine("=          [3] - Search StoreFront Info                  =");
            Console.WriteLine("=          [4] - View Products & Orders                  =");
            Console.WriteLine("=          [5] - Bulk Order Products Menu                =");
            Console.WriteLine("=          [6] - SELECT STORE - STORE SHOP NOW           =");
            Console.WriteLine("==========================================================");
        }

        public string UserSelection()
        {
            Log.Information("User is selecting an input");
            string userInput = Console.ReadLine();
            while(string.IsNullOrEmpty(userInput))
            {
                Log.Information("User is retrying to select an input");
                Console.WriteLine("Please Input a Selection");
                userInput = Console.ReadLine();
            }
            switch (userInput)
            {
                case "0":
                    Log.Information("User is selecting Store Main Menu");
                    return "StoreMainMenu";
                case "1":
                    Log.Information("User is selecting New Customers Menu");
                    return "NewCustomersMenu";
                case "2":
                    Log.Information("User is selecting Find Customers ID Menu");
                    return "SearchCustomersMenu";                    
                case "3":
                    Log.Information("User is selecting Search Store Fronts Menu");
                    return "SearchStoreFrontsMenu";
                case "4":
                    Log.Information("User is selecting Add Business Transaction Menu");
                    return "AddBusinessTransaction";               
                case "5":
                    Log.Information("User is selecting Add New Order Menu");
                    return "AddNewOrderMenu";
                case "6":
                    Log.Information("User is selecting Shop NOW");
                    return "AddShopNowMenu";                             
                default:
                    Log.Information("User has made an invalid selection");
                    Console.WriteLine("Invalid Selection. Please Try Again. Press Enter to Continue");
                    Console.ReadLine();
                    return "StoreMainMenu";
            }
        }
    }
}