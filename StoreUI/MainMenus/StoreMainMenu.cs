
namespace StoreUI
{
    
    /// <summary>
    /// Store Menu Inherits Interface --> Entry Point
    /// User Selection Methods Implemented
    /// </summary>
    public class StoreMainMenu : IMenu
    {
 
        /// <summary>
        /// Displays Store Menu
        /// </summary>
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
            Console.WriteLine("        ======================================");
            Console.WriteLine("        =            Welcome To              =");
            Console.WriteLine("        = Retro Barbarian Online Gaming Lair =");
            Console.WriteLine("        ======================================");
            Console.WriteLine("        =     Please Make a Selection        =");
            Console.WriteLine("        =      [0] Exit The Store            =");
            Console.WriteLine("        =      [1] Customer Menu             =");
            Console.WriteLine("        =      [2] Administration Menu       =");       
            Console.WriteLine("        ======================================");
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
        }

        /// <summary>
        /// Get User Input and Select Case Choice
        /// </summary>
        /// <returns>Returns String Selection</returns>
        public string UserSelection()
        {
            //Read in Customer Input 
            Log.Information("User is selection an input");
            string UserInput = Console.ReadLine();
            while(string.IsNullOrEmpty(UserInput))
            {
                Log.Information("User is retrying to input a new selection");
                Console.WriteLine("Please Input a Selection");
                UserInput = Console.ReadLine();
            }
            switch (UserInput)
            {
                case "0":
                    Log.Information("User has Exited The Program");
                    Log.CloseAndFlush(); //To close our logger resource
                    return "Exit";
                case "1":
                Log.Information("User is selecting Customers Menu");
                    return "CustomersMenu";
                case "2":
                Log.Information("User is selecting Administration Menu");
                    return "AdministrationMenu";
                default :
                Log.Information("User has made an invalid Selection");
                    Console.WriteLine("Invalid Seleciton. Please Try Again. Press Enter to Continue.");
                    Console.ReadLine();
                    return "StoreMainMenu";

            }
        }
    }
}