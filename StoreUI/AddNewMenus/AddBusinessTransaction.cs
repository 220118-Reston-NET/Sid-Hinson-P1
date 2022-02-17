using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AddBusinessTransaction : IMenu
    {

        //************TODO: View Order History
        //************TODO: View Current Orders
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
            Console.WriteLine("     ================================================");
            Console.WriteLine("     = Retro Barbarian Online Gaming Lair Shop Menu =");
            Console.WriteLine("     ================================================");
            Console.WriteLine("     =         Enter Number to Select Option        =");     
            Console.WriteLine("     ================================================");
            Console.WriteLine("     =[0]     - Return to Main Menu / Exit          =");
            Console.WriteLine("     =[1]     - Display Product By Category         =");
            Console.WriteLine("     =[2]     - Search For Products by Criteria     =");
            Console.WriteLine("     =[3]     - Create/Edit Product Order           =");
            Console.WriteLine("     =[4]     - View Your Order History             =");
            Console.WriteLine("===========================================================");
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
        }

        public string UserSelection()
        {
             Log.Information("User is making a selection");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                //Return to Main Menu
                case "0":
                Log.Information("User is selecting Customers Menu");
                return "CustomersMenu";


                //Display Products by Category
                case "1":
                Log.Information("User is selecting Add Products Menu");
                return "AddProductsDisplay";

                //Search Products by Criteria
                case "2":
                Log.Information("User is selecting Search Products Menu");
                return "SearchProductsMenu"; 


                //Create Edit Orders
                case "3":
                Log.Information("User is selecting Add New Order Menu");
                return "AddNewOrderMenu";


                //View Order History
                case "4":
                Log.Information("User is selecting Search Orders Customer Menu");
                return "SearchOrdersCMenu";

                //Default Case
                default:
                Log.Information("User Has made an Invalid Selection");
                Console.WriteLine("Please Enter a VALID Selection - Press Enter to Continue");
                Console.ReadLine();
                return "AddBusinessTransaction";
            }
        }
    }
}