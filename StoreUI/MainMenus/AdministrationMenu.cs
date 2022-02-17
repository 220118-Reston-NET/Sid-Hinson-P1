

namespace StoreUI
{
    public class AdministrationMenu : IMenu
    {
        public void MenuDisplay()
        {
            //********TODO: View/Update Order Inventory
            Console.Clear();
            Console.WriteLine("         ==================================================    ");
            Console.WriteLine("         =             Administration Menu                =    ");
            Console.WriteLine("         ==================================================    ");
            Console.WriteLine("         =               Select Option                    =    ");     
            Console.WriteLine("   ============================================================");
            Console.WriteLine("   = [0] - Return to Main Menu / Exit                         =");
            Console.WriteLine("   = [1] - Enter New Customer                                 ="); 
            Console.WriteLine("   = [2] - Search For Customer / Find Info                    =");
            Console.WriteLine("   = [3] - Enter New StoreFront                               =");
            Console.WriteLine("   = [4] - Search For StoreFront                              =");
            Console.WriteLine("   = [5] - Enter New Warehouse Product                        =");
            Console.WriteLine("   = [6] - Search For Warehouse Product                       =");
            Console.WriteLine("   = [7] - Check Orders Status/StoreFront Order Status        =");
            Console.WriteLine("   = [8] - Check Product Level/Replenish Level                =");
            Console.WriteLine("   ============================================================");

        }

        public string UserSelection()
        {
            Log.Information("User is making a Selection");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    Log.Information("User is selecting Store Main Menu");
                    return "StoreMainMenu";
                case "1":
                    Log.Information("User is selecting New Customers Menu");
                    return "NewCustomersMenu";
                case "2":
                    Log.Information("User is selecting Search Customers Menu");
                    return "SearchCustomersMenu";
                case "3":
                    Log.Information("User is selecting Store Fronts Menu");
                    return "NewStoreFrontsMenu";
                case "4":
                    Log.Information("User is selecting Search Store Fronts Menu");
                    return "SearchStoreFrontsMenu";
                case "5":
                    Log.Information("User is selecting Add New Products menu");
                    return "AddNewProductsMenu";
                case "6":
                    Log.Information("User is selecting Search Products Menu");
                    return "SearchProductsMenu";
                case "7":
                    Log.Information("User is selecting Admin Orders History");
                    return "AdminOrderMenu";           
                case "8":
                    Log.Information("User is selecting Admin Check/Update Product");
                    return "AdminProductMenu";
                default:
                    Log.Information("User is making an Invalid Selection");
                    Console.WriteLine("Invalid Selection. Please Try Again. Press Enter to Continue");
                    Console.ReadLine();
                    return "NewCustomersMenu";
            }
        }
    }
}