using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class SearchStoreFrontsMenu : IMenu
    {

        //Dependecy Injection
        private IStoreFrontsBL _frontBL;

        public SearchStoreFrontsMenu(IStoreFrontsBL p_frontBL)
        {
            _frontBL = p_frontBL; 
        }


        /// <summary>
        /// Displays Menu
        /// </summary>
        public void MenuDisplay()
        {   
            Console.Clear();
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
            Console.WriteLine("     ============================================");
            Console.WriteLine("     =          Menu : Search StoreFronts       =");
            Console.WriteLine("     ============================================");
            Console.WriteLine("     =              Select Option :             =");
            Console.WriteLine("     = [0] - Exit Search                        =");
            Console.WriteLine("     = [1] - Find StoreFront Information [#]    =");
            Console.WriteLine("     = [2] - Find StoreFront Information [City] =");
            Console.WriteLine("     ============================================");
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
        }



        /// <summary>
        /// Allows User to Pick Selection
        /// </summary>
        /// <returns>menu object</returns>
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
                    Console.WriteLine("Please Enter a Store Front Number to find its information.");
                    //Testing for an Integer Value
                    bool isNumber = false;
                    string Test = Console.ReadLine();
                    isNumber = int.TryParse(Test, out int p_StoreNumber);
                    while(isNumber == false)
                    {
                        Console.WriteLine("You Must Enter an Integer value:");
                        string Retry = Console.ReadLine();
                        isNumber = int.TryParse(Retry, out int result);
                        p_StoreNumber = result;

                    }
                    
                    //Find Store
                    List<StoreFronts> listofStoreFronts = _frontBL.SearchStoreFronts(p_StoreNumber);
                    if(listofStoreFronts.Any())
                    {
                        //Return the Store
                        foreach (var StoreFront in listofStoreFronts)
                        {
                            Console.WriteLine(StoreFront);
                        }
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        return "SearchStoreFrontsMenu";
                    }
                    else
                    {
                        //Confirm to User no result
                        Console.WriteLine("Your search did not return any results. Please try again");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        return "SearchStoreFrontsMenu";
                    }
                    
                case "2":
                        Console.WriteLine("Please Enter a Store Front City to Search for Locations");
                        string cityinput = Console.ReadLine();
                        cityinput = cityinput.ToUpper();
                        List<StoreFronts> listofStoreFrontsCity = _frontBL.GetAllStoreFronts();
                        foreach(StoreFronts store in listofStoreFrontsCity)
                        {
                            if(store.StoreCity == cityinput)
                            {
                                Console.WriteLine("******************");
                                Console.WriteLine(store);
                                Console.WriteLine("******************");
                            }
                            else
                            {
                                Console.WriteLine("No stores were located. Please try again.");
                            }
                        }
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        return "SearchStoreFrontsMenu";
                default:
                    Console.WriteLine("Invalid Selection. Please Try Again.");
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "StoreMainMenu";
            }
        }
    }
}