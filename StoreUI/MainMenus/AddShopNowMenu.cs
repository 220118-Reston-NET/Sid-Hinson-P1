using StoreModel;
using StoreBL;
namespace StoreUI
{

    public class AddShopNowMenu: IMenu
    {
        private static List<LineItems> _shoppingCart = new List<LineItems>();
        // private static LineItems CartItem = new LineItems();
        private static Orders _shoppingOrder = new Orders();
        private static Products _productInfo = new Products();
        public static double OrderTotal;

        //Dependency Injection
        private IProductsBL _productBL;
        private IOrdersBL _orderBL;
        private ICustomersBL _customerBL;
        private IInventoryBL _inv;

        private IStoreFrontsBL _store;
        public AddShopNowMenu(IOrdersBL p_orderBL, IProductsBL p_productBl, ICustomersBL p_customerBL, IInventoryBL p_inv, IStoreFrontsBL p_store)
        {

            _orderBL = p_orderBL;
            _productBL = p_productBl;
            _customerBL = p_customerBL;
            _inv = p_inv;
            _store = p_store;
        }

        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
            Console.WriteLine("=          RETRO BARBARIAN ONLINE GAMING LAIR            =");
            Console.WriteLine("==========================================================");
            Console.WriteLine("=         *SHOP NOW!  - MAKE SHOPPING EASIER!*           =");
            Console.WriteLine("==========================================================");
            Console.WriteLine("              Press Enter to Continue                     ");
            Console.ReadLine();
        }

         public string UserSelection()
       {

            if(_productInfo.StoreID != 0)
            {
                
            }
            else
            {
                Console.Clear();
                Console.WriteLine("==========================================================");
                Console.WriteLine("=          RETRO BARBARIAN ONLINE GAMING LAIR            =");
                Console.WriteLine("==========================================================");
                Console.WriteLine("Please Enter a Store ID Number from the List :");
                List<StoreFronts> choice = _store.GetAllStoreFronts();
                foreach(StoreFronts store in choice)
                {
                    Console.WriteLine("*********************");
                    Console.WriteLine(store);
                    Console.WriteLine("*********************");
                }
                while(_productInfo.StoreID == 0)
                {
                    try
                    {
                        Console.WriteLine("Please Enter Store Number :");
                        _productInfo.StoreID = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("You Must Enter a Valid Store Number");
                        Console.WriteLine("Press Enter to Continue");
                    }
                }

            }

            Console.WriteLine("==========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("===========================================================");
            Console.WriteLine("    SHOP NOW! is automated for quick, easy ordering.");
            Console.WriteLine("Please go to Bulk Order Products Menu for precise ordering.");
            Console.WriteLine("===========================================================");
            Console.WriteLine("=                 Select Category                          ");
            Console.WriteLine("===========================================================");
            Console.WriteLine("=[0] Exit ");
            Console.WriteLine("=[1] Games "); 
            Console.WriteLine("=[2] Systems ");
            Console.WriteLine("=[3] Merchandise ");
            Console.WriteLine("===========================================================");
            Console.WriteLine("=                     Finalize                            =");
            Console.WriteLine("===========================================================");
            Console.WriteLine("=[4] Checkout Order ");
            Console.WriteLine("=[5] Clear All Items in Order ");
            Console.WriteLine("=[6] Display Current Items in Cart");
            Console.WriteLine("===========================================================");
            string userchoice1 = Console.ReadLine();
            switch(userchoice1)
            {
                case "1":
                    Log.Information("User is selecting Game Category");
                    string p_ch1 = "GAME";
                    Console.Clear();
                    Console.WriteLine("=========================================================="); 
                    Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
                    Console.WriteLine("==========================================================");
                    Console.WriteLine("Here are the products for your store and category:");
                    List<Products> choice1 = _productBL.SearchProductsCat(p_ch1, _productInfo.StoreID);
                    foreach(Products product in choice1)
                    {
                        Console.WriteLine("*****************");
                        Console.WriteLine(product);
                        Console.WriteLine("*****************");
                        Console.WriteLine("Would You Like to add this product to your cart? Type YES to add.");
                        string userchoice = Console.ReadLine();
                        userchoice = userchoice.ToUpper();
                        switch(userchoice)
                        {   case "YES":
                                Console.WriteLine("How Many Would You Like To Buy?");
                                int userbuy = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("****************************");
                                Console.WriteLine("* Checking Inventory ......*");
                                Console.WriteLine("****************************");
                                Console.WriteLine(" Please Press Enter");
                                Console.ReadLine();
                                Console.Clear();
                                LineItems CartItem = new LineItems();
                                CartItem.StoreID = _productInfo.StoreID;
                                CartItem.ProductID = product.ProductID;
                                CartItem.ProductQuantity = userbuy;
                                OrderTotal += (_productBL.GetPrice(CartItem.ProductID) * CartItem.ProductQuantity);
                                
                                //Validate Inventory Level
                                Inventory parlevel =_inv.FindItemLevel(_productInfo.StoreID, CartItem.ProductID);
                                parlevel.ProductQuantity -= CartItem.ProductQuantity;

                                if(parlevel.ProductQuantity >= 0)
                                {
                                    //Add Item to Shopping Cart
                                    _shoppingCart.Add(CartItem);
                                    Console.WriteLine("****************************");
                                    Console.WriteLine("This Item was Added to cart.");
                                    Console.WriteLine(CartItem);
                                    Console.WriteLine("****************************");
                                    Console.WriteLine(" Please Press Enter");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("**********************************************************************");
                                    Console.WriteLine("We are sorry, but your we cannot fulfill your order. We must restock.");
                                    Console.WriteLine("**********************************************************************");
                                    Console.WriteLine(" Please Press Enter");
                                    Console.ReadLine();
                                }
                                break;

                            default:
                                break;
                        }

                    }
                    return "AddShopNowMenu";



                case "2":
                    Log.Information("User is selecting System Category");
                    string p_ch2 = "SYSTEM";
                    Console.Clear();
                    Console.WriteLine("=========================================================="); 
                    Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
                    Console.WriteLine("==========================================================");
                    Console.WriteLine("Here are the products for your store and category:");
                    List<Products> choice2 = _productBL.SearchProductsCat(p_ch2, _productInfo.StoreID);
                    foreach(Products product in choice2)
                    {
                        Console.WriteLine("*****************");
                        Console.WriteLine(product);
                        Console.WriteLine("*****************");
                        Console.WriteLine("Would You Like to add this product to your cart? Type YES to add.");
                        string userchoice = Console.ReadLine();
                        userchoice = userchoice.ToUpper();
                        switch(userchoice)
                        {   case "YES":
                                Console.WriteLine("How Many Would You Like To Buy?");
                                int userbuy = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("****************************");
                                Console.WriteLine("* Checking Inventory ......*");
                                Console.WriteLine("****************************");
                                Console.WriteLine(" Please Press Enter");
                                Console.ReadLine();
                                Console.Clear();
                                LineItems CartItem = new LineItems();
                                CartItem.StoreID = _productInfo.StoreID;
                                CartItem.ProductID = product.ProductID;
                                CartItem.ProductQuantity = userbuy;
                                OrderTotal += (_productBL.GetPrice(CartItem.ProductID) * CartItem.ProductQuantity);
                                
                                //Validate Inventory Level
                                Inventory parlevel =_inv.FindItemLevel(_productInfo.StoreID, CartItem.ProductID);
                                parlevel.ProductQuantity -= CartItem.ProductQuantity;

                                if(parlevel.ProductQuantity >= 0)
                                {
                                    //Add Item to Shopping Cart
                                    _shoppingCart.Add(CartItem);
                                    Console.WriteLine("****************************");
                                    Console.WriteLine("This Item was Added to cart.");
                                    Console.WriteLine(CartItem);
                                    Console.WriteLine("****************************");
                                    Console.WriteLine(" Please Press Enter");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("**********************************************************************");
                                    Console.WriteLine("We are sorry, but your we cannot fulfill your order. We must restock.");
                                    Console.WriteLine("**********************************************************************");
                                    Console.WriteLine(" Please Press Enter");
                                    Console.ReadLine();
                                }
                                break;

                            default:
                                break;
                        }

                    }
                    return "AddShopNowMenu";
                   


                case "3":
                    Log.Information("User is selecting Merchandise Category");
                    string p_ch3 = "MERCHANDISE";
                    Console.Clear();
                    Console.WriteLine("=========================================================="); 
                    Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
                    Console.WriteLine("==========================================================");
                    Console.WriteLine("Here are the products for your store and category:");
                    List<Products> choice3 = _productBL.SearchProductsCat(p_ch3, _productInfo.StoreID);
                    foreach(Products product in choice3)
                    {
                        Console.WriteLine("*****************");
                        Console.WriteLine(product);
                        Console.WriteLine("*****************");
                        Console.WriteLine("Would You Like to add this product to your cart? Type YES to add.");
                        string userchoice = Console.ReadLine();
                        userchoice = userchoice.ToUpper();
                        switch(userchoice)
                        {   case "YES":
                                Console.WriteLine("How Many Would You Like To Buy?");
                                int userbuy = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("****************************");
                                Console.WriteLine("* Checking Inventory ......*");
                                Console.WriteLine("****************************");
                                Console.WriteLine(" Please Press Enter");
                                Console.ReadLine();
                                Console.Clear();
                                LineItems CartItem = new LineItems();
                                CartItem.StoreID = _productInfo.StoreID;
                                CartItem.ProductID = product.ProductID;
                                CartItem.ProductQuantity = userbuy;
                                OrderTotal += (_productBL.GetPrice(CartItem.ProductID) * CartItem.ProductQuantity);
                                
                                //Validate Inventory Level
                                Inventory parlevel =_inv.FindItemLevel(_productInfo.StoreID, CartItem.ProductID);
                                parlevel.ProductQuantity -= CartItem.ProductQuantity;

                                if(parlevel.ProductQuantity >= 0)
                                {
                                    //Add Item to Shopping Cart
                                    _shoppingCart.Add(CartItem);
                                    Console.WriteLine("****************************");
                                    Console.WriteLine("This Item was Added to cart.");
                                    Console.WriteLine(CartItem);
                                    Console.WriteLine("****************************");
                                    Console.WriteLine(" Please Press Enter");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("**********************************************************************");
                                    Console.WriteLine("We are sorry, but your we cannot fulfill your order. We must restock.");
                                    Console.WriteLine("**********************************************************************");
                                    Console.WriteLine(" Please Press Enter");
                                    Console.ReadLine();
                                }
                                break;

                            default:
                                break;
                        }

                    }
                    return "AddShopNowMenu";


                case "0":
                    Log.Information("User is exiting to the Store Main Menu");
                    return "StoreMainMenu";

                case "5":
                    Log.Information("User is clearing the Order");
                    _shoppingCart.Clear();
                    OrderTotal = 0;
                    Console.WriteLine("Order has been cleared. Press Enter to Continue");
                    Console.ReadLine();
                    return "AddShopNowMenu";


                case "6":
                    Log.Information("User is Displaying the Order");
                    _orderBL.DisplayCart(_shoppingCart);
                    Console.WriteLine($"Current Order Total = ${OrderTotal}");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return "AddShopNowMenu";

                    

                case "4":
                    Log.Information("User is selecting Finalize Order");
                    Console.Clear();
                    try
                        {
                            Log.Information("User is attempting to Save their Order to the DB");
                            Console.Clear();
                            _orderBL.DisplayGraphic();

                            //Get Inputs From User - these are parameterized to get the ID
                            Console.WriteLine("*************************************************************");
                            Console.WriteLine("* To Process Each Order, Please Input Your Email and Password");
                            Console.WriteLine("*************************************************************");
                            Log.Information("User is inputting their email address");                   
                            Console.WriteLine("* Please Enter Your User Email");
                            string userEmail = Console.ReadLine();
                            userEmail = userEmail.ToUpper();
                            
                            Log.Information("User is inputting their email password");
                            Console.WriteLine("* Please Enter Your User Password");
                            string userPass = Console.ReadLine();

                        
                            //**Create Shopping Order To Send to REPO**
                            //Get CustomerID
                            Console.Clear();
                            Console.WriteLine("******************************");
                            Console.WriteLine("* Getting Customer ID ........");
                            Console.WriteLine("******************************");
                            do
                            {
                                _shoppingOrder.OrderCustID = _customerBL.GetID(userEmail, userPass);
                                Console.WriteLine("Customer ID : " + _shoppingOrder.OrderCustID);

                            }while(_shoppingOrder.OrderCustID == 0);

                            //Adding StoreID
                            _shoppingOrder.OrderStoreID = _productInfo.StoreID;
                            Console.WriteLine("Your StoreID is: " + _shoppingOrder.OrderStoreID);

                            //Adding Date Time of Order
                            DateTime OrderDate = DateTime.Now;
                            _shoppingOrder.OrderDate = OrderDate.ToString("MM/dd/yyyy");

                            //Adding Order Total
                            _shoppingOrder.OrderTotal = OrderTotal;

                            //Adding Line Items Cart to Order
                            _shoppingOrder.OrderLineItems = new List<LineItems>();
                            _shoppingOrder.OrderLineItems = _shoppingCart;
                            _shoppingOrder.OrderStatus = "PROCESSING";

                            //Add Order to Repo
                            Console.WriteLine("**********************************");
                            Console.WriteLine("* Attempting to Add Order .......*");
                            _orderBL.AddOrders(_shoppingOrder);
                            Console.WriteLine("* Order Added!                   *"); 
                            Console.WriteLine("**********************************");

                            //Find the OrderID
                            List<Orders> getcount = new List<Orders>();
                            getcount = _orderBL.GetAllOrders();
                            int OrderID = getcount.Count();
                            Console.WriteLine("**********************************");
                            Console.WriteLine("Your Order ID is : " + OrderID);
                            Console.WriteLine("**********************************");
                            Console.ReadLine();
                            

                            //Display Items Ordered
                            Console.WriteLine("**********************************");
                            Console.WriteLine("These were the Items Ordered");
                            _orderBL.DisplayCart(_shoppingOrder.OrderLineItems);
                            Console.WriteLine("**********************************");
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadLine();

                            //Add All LineItems to Repo
                            foreach(LineItems item in _shoppingCart)
                            {
                                item.OrderID = OrderID;
                                _orderBL.AddLineItems(item);
                            }
                            
                        //Update Inventory
                        //Set IDs, Pull Inventory Item Info, subtract quantity, reupdate Item totals in DB
                        //Throws exceptions when needed
                        foreach(LineItems item in _shoppingCart)
                        {
                            // //New Inventory object every loop
                            // Inventory inventoryobj1 = new Inventory();
                            // //Populating Fields
                            // inventoryobj1.StoreID = item.StoreID;
                            // inventoryobj1.ProductID = item.ProductID;
                            //Calculate Quantity to subtract in a Variable
                            int subtractvalue = item.ProductQuantity;
                            Console.WriteLine("Setting Inventory");

                            //Inventory object to hold the actual Row Record We Need to Manipulate
                            Inventory updateinv = _inv.FindItemLevel(item.StoreID, item.ProductID);
                            Console.WriteLine($"Inventory previously held : {updateinv.ProductQuantity}");
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadLine();
                            //Subtract the Value From the Quantity
                            updateinv.ProductQuantity -= subtractvalue;
                            Console.WriteLine($"Inventory will now have {updateinv.ProductQuantity}");
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadLine();
                                if(updateinv.ProductQuantity < 0)
                                {
                                    Console.WriteLine("*********************************************************************************");
                                    Console.WriteLine($"We cannot fulfill your order. We are missing {updateinv.ProductQuantity} units *");
                                    Console.WriteLine("*********************************************************************************");
                                    Console.WriteLine("Press Enter to Continue");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    _inv.UpdateInventory(updateinv);
                                    Console.WriteLine("****************************************");
                                    Console.WriteLine($"Inventory Item Now Added : {updateinv}");
                                    Console.WriteLine("****************************************");
                                    Console.WriteLine("Press Enter to Continue");
                                    Console.ReadLine();
                                }
                        }
                    }
                    catch(InvalidDataException)
                    {
                        Console.WriteLine("The Data could not be processed.");
                        Console.WriteLine("Please Look at your Order Input Data and Try Again.");
                    }
                    _shoppingCart.Clear();
                    _shoppingOrder.OrderTotal = 0;
                return "AddShopNowMenu";


                default:
                    Log.Information("User made an invalid selection");
                    return "AddShopNowMenu";

            }
       }
    }
}
