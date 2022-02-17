using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AddNewProductsMenu : IMenu
    {
        //Static Class for variable Consistently Across the Created Class Objects

        private static Inventory _newInventory = new Inventory();
        private static Products _newProduct = new Products();
        //Dependency Injection
        private IInventoryBL _invBL;
        private IProductsBL _productBL;
        //
        public AddNewProductsMenu(IProductsBL p_product, IInventoryBL p_inv)
        {
            _productBL = p_product;
            _invBL = p_inv;
        }
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=             Menu : Add Product               =");
            Console.WriteLine("================================================");
            Console.WriteLine("=       Enter New Product Info : Select        =");     
            Console.WriteLine("================================================");
            Console.WriteLine("=[0] - Return to Main Menu");
            Console.WriteLine("=[1] - Enter Store Number: " + _newProduct.StoreID);
            Console.WriteLine("=[2] - Enter Product Name: " + _newProduct.ProductName);
            Console.WriteLine("=[3] - Enter Product Company: " + _newProduct.ProductCompany);
            Console.WriteLine("=[4] - Enter Product Price: " + _newProduct.ProductPrice); 
            Console.WriteLine("=[5] - Enter Product Description: " + _newProduct.ProductDescription);
            Console.WriteLine("=[6] - Enter Product Category: " + _newProduct.ProductCategory);
            Console.WriteLine("=[7] - Enter Product Quantity: " + _newInventory.ProductQuantity);
            Console.WriteLine("=[8] - Update & Save Information");
            Console.WriteLine("===============================================");
        }

        //***TODO:VALIDATION ON ALL INPUTS
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
                    Log.Information("User is inputting the Store Number");
                    Console.WriteLine("Enter a Store Number :");
                    _newProduct.StoreID = Convert.ToInt32(Console.ReadLine());
                    while(_newProduct.StoreID < 0)
                    {
                        Console.WriteLine("You Must Enter a Numerical, Postive Whole Number for Store ID");
                        _newProduct.StoreID = Convert.ToInt32(Console.ReadLine());
                    }   
                    return "AddNewProductsMenu";


                case "2":
                    Log.Information("User is inputting the Product Name");
                    Console.WriteLine("Enter a Product Name : ");
                    _newProduct.ProductName = Console.ReadLine();
                    _newProduct.ProductName = _newProduct.ProductName.ToUpper();
                    return "AddNewProductsMenu";


                case "3":
                    Log.Information("User is inputting the Product Company");
                    Console.WriteLine("Enter a Product Company : ");
                    _newProduct.ProductCompany = Console.ReadLine();
                    _newProduct.ProductCompany = _newProduct.ProductCompany.ToUpper();
                    return "AddNewProductsMenu";

                // Product Description Entry
                case "4":
                    Log.Information("User is inputting the Product Price");
                    Console.WriteLine("Enter a Product Price : ");
                    _newProduct.ProductPrice = Convert.ToDouble(Console.ReadLine());
                    return "AddNewProductsMenu";

                // Product Description Entry
                case "5":
                    Log.Information("User is inputting the Product Description");
                    Console.WriteLine("Enter a Product Description : ");
                    _newProduct.ProductDescription = Console.ReadLine();
                    _newProduct.ProductDescription = _newProduct.ProductDescription.ToUpper();
                    return "AddNewProductsMenu";

                // Product Category Entry
                case "6":
                    Log.Information("User is inputting the Product Category");
                    Console.WriteLine("Enter a Product Category : ");
                    _newProduct.ProductCategory = Console.ReadLine();
                    _newProduct.ProductCategory = _newProduct.ProductCategory.ToUpper();
                    return "AddNewProductsMenu";

                // Product Quantity Entry
                case "7":
                    Log.Information("User is inputting the Product Quantity");
                    Console.WriteLine("Enter a Quantity : ");
                    _newInventory.ProductQuantity = Convert.ToInt32(Console.ReadLine());
                    while(_newInventory.ProductQuantity < 0)
                    {
                        Console.WriteLine("Quantity Must be greater than 0. Enter a New Quantity : ");
                        _newInventory.ProductQuantity = Convert.ToInt32(Console.ReadLine());
                    }
                    return "AddNewProductsMenu";



                case "8":
                    //Add Product to DB
                    Log.Information("User is attempting to Save the Product to the DB");
                    try
                    {   
                         //Add Product To DB
                         _productBL.AddProducts(_newProduct);
                         Console.WriteLine("This Product Was Added. Press Enter");
                         Console.WriteLine(_newProduct);
                         Console.ReadLine();
                         //Add Product Information to Inventory
                         List<Products> getelementcount = new List<Products>();
                         getelementcount = _productBL.GetAllProducts();
                        //  Console.WriteLine("This List Was returned : Press Enter");
                        //  foreach(Products product in getelementcount)
                        //  {
                        //      Console.WriteLine(product);
                        //  }
                        //  Console.ReadLine();
                         int ProductID = getelementcount.Count();
                         Console.WriteLine($"Product ID is: {ProductID}. Press Enter.");
                         Console.ReadLine();
                         _newInventory.StoreID = _newProduct.StoreID;
                         _newInventory.ProductID = ProductID;
                         //Inv already has quantity assigned by here --> Add to repo
                         _invBL.AddInventory(_newInventory);
                         Console.WriteLine("This Inventory Was Added. Press Enter");
                        //  Console.WriteLine(_newInventory);
                         Console.ReadLine();
                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Something Unexpected Happened");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    return "AddNewProductsMenu";


                    default:
                    Log.Information("User has made an Invalid Selection");
                    Console.WriteLine("You have made an Invalid Selection - Please Press Enter to Continue");
                    Console.ReadLine();
                    return "AddNewProductsMenu";
            }
        }
    }
}