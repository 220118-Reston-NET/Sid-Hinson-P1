using StoreModel;
using StoreBL;

namespace StoreUI
{
    public class AdminProductMenu: IMenu
    {
        private IInventoryBL _invBL;
        private IProductsBL _productBL;
        //
        public AdminProductMenu(IProductsBL p_product, IInventoryBL p_inv)
        {
            _productBL = p_product;
            _invBL = p_inv;
        }
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=        Menu : Product Administration         =");
            Console.WriteLine("================================================");
            Console.WriteLine("=       Check or Update Warehouse Products     =");     
            Console.WriteLine("================================================");
            Console.WriteLine("=[0] - Return to Main Menu                      0");
            Console.WriteLine("=[1] - Check Inventory Level - [P#id] [sf#id]   ");
            Console.WriteLine("=[2] - Replenish Inventory - [P#id] [sf#id]     ");
            Console.WriteLine("=[3] - Search Products - Find Product ID        ");
            Console.WriteLine("================================================");
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


                case "1":
                    Log.Information("User is selecting Check Product Level");
                    Console.Clear();
                    Console.WriteLine("================================================");
                    Console.WriteLine("=           Check Inventory Level                =");     
                    Console.WriteLine("================================================");
                    Console.WriteLine("Enter ProductID");
                    int p_prodID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter StoreID");
                    int p_prodstoreID = Convert.ToInt32(Console.ReadLine());
                    // Inventory MyInv = _invBL.Search4Inv(p_prodstoreID, p_prodID);
                    Inventory MyInv = _invBL.FindItemLevel(p_prodstoreID, p_prodID);
                    if(MyInv != null)
                    {
                        Console.WriteLine("Inventory Located :");
                        Console.WriteLine(MyInv);
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("No Inventory Located :");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    return "AdminProductMenu";


                case "2":
                    Log.Information("User is selecting Replenish Product");
                    Log.Information("User is selecting Check Product Level");
                    Console.Clear();
                    Console.WriteLine("================================================");
                    Console.WriteLine("=           Replenish Inventory Level          =");     
                    Console.WriteLine("================================================");
                    Console.WriteLine("Enter ProductID");
                    int p_prodinvID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter StoreID");
                    int p_prodinvstoreID = Convert.ToInt32(Console.ReadLine());
                    Inventory RepInv = _invBL.FindItemLevel(p_prodinvstoreID, p_prodinvID);
                    if(RepInv != null)
                    {
                        Console.WriteLine("Inventory Located :");
                        Console.WriteLine(RepInv);
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("No Inventory Located :");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        return "AdminProductMenu";
                    }
                    Console.WriteLine("Please Enter New Inventory Quantity Level");
                    int newLevel = Convert.ToInt32(Console.ReadLine());
                    RepInv.ProductQuantity = newLevel;
                    Console.WriteLine($"New Level To Be Entered: {RepInv.ProductQuantity}");
                    Console.WriteLine("Do you wish to Continue? This cannot be undone.");
                    Console.WriteLine("Type 'Yes' to Commit Changes. Type 'No' to Exit.");
                    string answer = Console.ReadLine();
                    answer = answer.ToUpper();
                    if(answer == "YES")
                    {
                        Console.ReadLine();
                        _invBL.UpdateInventory(RepInv);
                        Console.WriteLine("Inventory Level updated. Press Enter to Continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("You will now exit this module. Press Enter to Continue");
                        Console.ReadLine();
                    }

                    return "AdminProductMenu";


                case "3":
                    Log.Information("User is selecting Search Products");
                    Console.Clear();
                    Console.WriteLine("================================================");
                    Console.WriteLine("=           Search Product / Find ID           =");     
                    Console.WriteLine("================================================");
                    Console.WriteLine("Enter Product Name");
                    string p_prodname = Console.ReadLine();
                    p_prodname = p_prodname.ToUpper();
                    Console.WriteLine("Enter Product StoreID");
                    int p_prodstore = Convert.ToInt32(Console.ReadLine());
                    Products MyProd = _productBL.SearchForProduct(p_prodname, p_prodstore);
                    if(MyProd != null)
                    {
                        Console.WriteLine("Product Located :");
                        Console.WriteLine(MyProd);
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("No Product Located :");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    return "AdminProductMenu";


                default:
                    return "AdminProductMenu";
                
            }
        }
    }
}