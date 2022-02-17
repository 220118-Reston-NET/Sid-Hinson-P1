using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class NewStoreFrontsMenu : IMenu
    {
        //Static Class for variable Consistently Across the Created Class Objects
        private static StoreFronts _newStoreFronts = new StoreFronts();
        //Dependency Injection
        private IStoreFrontsBL _frontBL;
        //
        public NewStoreFrontsMenu(IStoreFrontsBL p_front)
        {
            _frontBL = p_front;
        }
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=             Menu : Add StoreFront            =");
            Console.WriteLine("===============================================");
            Console.WriteLine("=       Enter New StoreFronts Info : Select       =");     
            Console.WriteLine("================================================");
            Console.WriteLine("=[0] - Return to Main Menu");
            Console.WriteLine("=[1] - Enter StoreFront Street Address: " + _newStoreFronts.StoreAddress );
            Console.WriteLine("=[2] - Enter StoreFront City: " + _newStoreFronts.StoreCity );        
            Console.WriteLine("=[3] - Enter StoreFront Zipcode: " + _newStoreFronts.StoreZipCode );
            Console.WriteLine("=[4] - Enter StoreFront State: " + _newStoreFronts.StoreState);
            Console.WriteLine("=[5] - Update & Save Information");
            Console.WriteLine("===============================================");
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
        }

        public string UserSelection()
        {
            Log.Information("User is inputting the Menu Selection");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    Log.Information("User is selecting Store Main Menu");
                    return "StoreMainMenu";

                // Store Address Entry
                case "1":
                    Log.Information("User is inputting the Store Front Street Address");
                    Console.WriteLine("Enter a Street Address : ");
                    _newStoreFronts.StoreAddress = Console.ReadLine();
                    _newStoreFronts.StoreAddress= _newStoreFronts.StoreAddress.ToUpper();
                    return "NewStoreFrontsMenu";

                // Store City Entry
                case "2":
                    Log.Information("User is inputting the Store Front City");
                    Console.WriteLine("Enter a Store City : ");
                    _newStoreFronts.StoreCity = Console.ReadLine();
                    _newStoreFronts.StoreCity = _newStoreFronts.StoreCity.ToUpper();
                    return "NewStoreFrontsMenu";

                // Store Zip Code entry
                case "3":
                   Log.Information("User is inputting the Store Front Zip Code");
                    Console.WriteLine("Enter a Zip Code: ");
                   _newStoreFronts.StoreZipCode = Console.ReadLine();
                    return "NewStoreFrontsMenu";

                // Store State Entry
                case "4":
                   Log.Information("User is inputting the Store Front State");
                    Console.WriteLine("Enter a State Location : ");
                    _newStoreFronts.StoreState = Console.ReadLine();
                    _newStoreFronts.StoreState = _newStoreFronts.StoreState.ToUpper();
                    return "NewStoreFrontsMenu";

                // * Save to DB
                case "5":
                    Log.Information("User is attempting to save the Store Front to The DB");
                    try
                    {   
                        _frontBL.AddStoreFronts(_newStoreFronts);

                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Something Unexpected Happened");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    return "NewStoreFrontsMenu";

                    
                    default:
                    Log.Information("User has made an Invalid Selection");
                    Console.WriteLine("You have made an Invalid Selection - Please Press Enter to Continue");
                    Console.ReadLine();
                    return "NewStoreFrontsMenu";
            }
        }
    }
}