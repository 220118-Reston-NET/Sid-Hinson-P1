using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AddProductsDisplay : IMenu
    {
        //Dependency Injection
        private IProductsBL _productBL;
        
        public AddProductsDisplay(IProductsBL p_productBl)
        {
            
            _productBL = p_productBl;
            
        }
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*      Retro Barbarian Online Gaming Lair Has (3) Locations to Serve You       *");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*               Please Enter a Store Front Number (1-3)                        *");
            Console.WriteLine("*                           You will Need:                                     *");
            Console.WriteLine("*          a Product Name, Company Name, StoreID and Quantity                  *");
            Console.WriteLine("*                to Order Products From This Terminal                          *");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*                        Press Enter When Ready                                *");
            Console.WriteLine("********************************************************************************");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("   =========================================================="); 
            Console.WriteLine("   )xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("   ==========================================================");
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("***** Enter a Category To See Inventory - Games - or - Systems ****");
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("*[0] = EXIT      [1] = Games     [2] = Systems   [3] = Merchandise*");
            Console.WriteLine("*******************************************************************");
        }

        public string UserSelection()
        {
            
            string userInput = Console.ReadLine();
            switch(userInput)
            {
                case "0":
                return "AddBusinessTransaction";



                case "1":
                string answer1 = "GAME";
                List<Products> listofprod1 = _productBL.SearchProductsCat(answer1);
                    foreach (var Products in listofprod1)
                    {
                        Console.WriteLine("***********************");
                        Console.WriteLine(Products);
                        Console.WriteLine("***********************");
                    }
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                return "AddProductsDisplay";



                case "2":
                string answer2 = "SYSTEM";
                List<Products> listofprod2 = _productBL.SearchProductsCat(answer2);
                    foreach (var Products in listofprod2)
                    {
                        Console.WriteLine("***********************");
                        Console.WriteLine(Products);
                        Console.WriteLine("***********************");
                    }
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                return "AddProductsDisplay";



                case "3":
                string answer3 = "MERCHANDISE";
                List<Products> listofprod3 = _productBL.SearchProductsCat(answer3);
                    foreach (var Products in listofprod3)
                    {
                        Console.WriteLine("***********************");
                        Console.WriteLine(Products);
                        Console.WriteLine("***********************");
                    }
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                return "AddProductsDisplay";  

                default:
                return "AddProductsDisplay";
             }
        }
    }
}















                


   