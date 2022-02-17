using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AddNewOrderMenu : IMenu
    {
        private static List<LineItems> _shoppingCart = new List<LineItems>();
        private static LineItems _cartItem = new LineItems();
        private static Orders _shoppingOrder = new Orders();
        private static Customers _customerInfo = new Customers();
        private static Products _productInfo = new Products();

        public static double OrderTotal;

        //Dependency Injection
        private IProductsBL _productBL;
        private IOrdersBL _orderBL;
        private ICustomersBL _customerBL;
        private IInventoryBL _inv;
        public AddNewOrderMenu(IOrdersBL p_orderBL, IProductsBL p_productBl, ICustomersBL p_customerBL, IInventoryBL p_inv)
        {
            _orderBL = p_orderBL;
            _productBL = p_productBl;
            _customerBL = p_customerBL;
            _inv = p_inv;
        }

        public void MenuDisplay()
        {

            Console.Clear();
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
            Console.WriteLine("==========================================================");
            Console.WriteLine("=                    Menu : Add Order                    =");
            Console.WriteLine("==========================================================");
            Console.WriteLine("=              Enter New Order Info : Select             =");     
            Console.WriteLine("==========================================================");
            Console.WriteLine("=[0] Return to Main Menu"); 
            Console.WriteLine("=[1] Store # - " + _productInfo.StoreID);
            Console.WriteLine("=[2] Product Name - " + _productInfo.ProductName);
            Console.WriteLine("=[3] Product Company - " + _productInfo.ProductCompany);
            Console.WriteLine("=[4] Quantity - " + _cartItem.ProductQuantity);  
            Console.WriteLine("=[5] Add Order to Cart");
            Console.WriteLine("=[6] Remove Orders From Cart");
            Console.WriteLine("=[7] Display Orders From Cart");
            Console.WriteLine("=[8] Save and Checkout Order");
            Console.WriteLine("==========================================================");
            Console.WriteLine("= * Last Item Added - ProductID - " + _productInfo.ProductID);
            Console.WriteLine("= * Last Item Added = Product Price - " + _productInfo.ProductPrice);
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");

        }
        
        public string UserSelection()
        {
            Log.Information("User is entering their selection");
            string userInput = Console.ReadLine();
            switch (userInput)
            {

                //Return to StoreMenu
                case "0":
                    Log.Information("User is selecting Store Main Menu");
                    return "StoreMainMenu";


                // Get Store Id of Product
                case "1":
                    Log.Information("User is entering the Store ID");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("Enter a Store ID :");
                    _productInfo.StoreID = Convert.ToInt32(Console.ReadLine());
                    return "AddNewOrderMenu";


                // Get Product Name
                case "2":
                    Log.Information("User is entering the Product Name");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("Enter a Product Name : ");
                    _productInfo.ProductName = Console.ReadLine();
                    _productInfo.ProductName = _productInfo.ProductName.ToUpper();
                    return "AddNewOrderMenu";


                //Get Product Company
                case "3":
                    Log.Information("User is entering the Product Company");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("Enter a Product Company :");
                    _productInfo.ProductCompany = Console.ReadLine();
                    _productInfo.ProductCompany = _productInfo.ProductCompany.ToUpper();
                    return "AddNewOrderMenu";



                //Get Product Quantity
                case "4":
                    Log.Information("User is entering the Product Quantity");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("Enter an Product Quantity : ");
                    _cartItem.ProductQuantity = Convert.ToInt32(Console.ReadLine());
                    return "AddNewOrderMenu";



                //Add Item to Cart
                case "5":
                    Log.Information("User is adding the Item to the Static Cart");
                    Console.Clear();
                    _orderBL.DisplayGraphic();


                    //Getting Values For Line Item
                    _productInfo.ProductID = _productBL.GetID(_productInfo.ProductName, _productInfo.ProductCompany, _productInfo.StoreID);
                    _productInfo.ProductPrice = _productBL.GetPrice(_productInfo.ProductID);
                    Console.WriteLine("*****************************************");
                    Console.WriteLine("* Find Product ID ..........");
                    Console.WriteLine("* Product ID is " + _productInfo.ProductID);
                    Console.WriteLine("*****************************************");
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    Console.Clear();

                    //ChecktoSee if ProductID returned
                    if(_productInfo.ProductID != 0)
                    {
                        //Building Line Item
                        _cartItem = _orderBL.AddItemFields(_productInfo.ProductID, _cartItem.ProductQuantity,_productInfo.StoreID, _productInfo.ProductPrice);
                        Console.WriteLine("*****************************************");
                        Console.WriteLine("* Item info : " + _cartItem);
                        Console.WriteLine("*****************************************");
                        Console.WriteLine("Press Enter");
                        Console.ReadLine();
                        Console.Clear();

                        //Running Total
                        _shoppingOrder.OrderTotal += (_productInfo.ProductPrice * _cartItem.ProductQuantity);
                        Console.WriteLine("*****************************************");
                        Console.WriteLine("* OrderTotal : " + _shoppingOrder.OrderTotal);
                        Console.WriteLine("*****************************************");
                        Console.WriteLine("Press Enter");
                        Console.ReadLine();
                        Console.Clear();

                        //Validate Inventory Level
                        // Inventory parlevel = new Inventory();
                        Inventory parlevel = _inv.FindItemLevel(_productInfo.StoreID, _productInfo.ProductID);
                        Console.WriteLine(_inv.FindItemLevel(_productInfo.StoreID, _productInfo.ProductID));
                        Console.WriteLine("***********************************");
                        Console.WriteLine("* Inventory Located:" + parlevel );
                        Console.WriteLine("***********************************");
                        Console.WriteLine("* Old Inventory LEVEL = " + parlevel.ProductQuantity);
                        Console.WriteLine("***********************************");
                        parlevel.ProductQuantity -= _cartItem.ProductQuantity;
                        Console.WriteLine("* Quantity to Subtract = " + _cartItem.ProductQuantity);
                        Console.WriteLine("* New Inventory Level = " + parlevel.ProductQuantity);
                        Console.WriteLine("***********************************");
                        Console.WriteLine("* Calculating Outcome");
                        Console.WriteLine("***********************************");
                        if(parlevel.ProductQuantity >= 0)
                        {
                            //Add Item to Shopping Cart
                            Console.WriteLine("****************************");
                            Console.WriteLine("*Product Can be Added.......");
                            _shoppingCart.Add(_cartItem);
                            Console.WriteLine("*This Item was Added to cart.");
                            Console.WriteLine("****************************");
                            Console.WriteLine("Press Enter");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("*****************************************************************");
                            Console.WriteLine("* Product can NOT be added to your order");
                            Console.WriteLine("* We are sorry, but we cannot fulfill your order. We must restock.");
                            Console.WriteLine("******************************************************************");
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("*************************************");
                        Console.WriteLine("Your Product Did not return an ID.");
                        Console.WriteLine("Please Try Again");
                        Console.WriteLine("Press Enter to Continue");
                        Console.WriteLine("*************************************");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    return "AddNewOrderMenu";



                // Clear Items from cart
                case "6":
                    Log.Information("User is clearing ALL Items in the Static Cart");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    _shoppingCart.Clear();
                    _shoppingOrder.OrderTotal = 0;
                    Console.WriteLine("*********************************************");
                    Console.WriteLine("Your Cart is Empty! Press Enter to Continue");
                    Console.WriteLine("********************************************");
                    Console.ReadLine();
                    Console.Clear();
                    return "AddNewOrderMenu";



                //Display ShoppingCart
                case "7":
                    Log.Information("User is displaying Items in the Static Cart");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("==============YourCart================");
                    _orderBL.DisplayCart(_shoppingCart);
                    Console.WriteLine("======================================");
                    Console.WriteLine($"Current Order Total = ${_shoppingOrder.OrderTotal}");
                    Console.WriteLine("======================================");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    Console.Clear();
                    return "AddNewOrderMenu";



                //**Save to DB Repo
                case "8":

                try
                 {
                    Log.Information("User is attempting to Save their Order to the DB");
                    Console.Clear();
                    _orderBL.DisplayGraphic();

                    //Get Inputs From User - these are parameterized to get the ID
                    Console.WriteLine("************************************************************");
                    Console.WriteLine("To Process Each Order, Please Input Your Email and Password");
                    Log.Information("User is inputting their email address");                   
                    Console.WriteLine("* Please Enter Your User Email");
                    Console.WriteLine("************************************************************");
                    string userEmail = Console.ReadLine();
                    userEmail = userEmail.ToUpper();
                    
                    Log.Information("User is inputting their email password");
                    Console.WriteLine("************************************************************");
                    Console.WriteLine("Please Enter Your User Password");
                    Console.WriteLine("************************************************************");
                    string userPass = Console.ReadLine();

                    //Must Find a Valid Customer ID
                    do
                    {
                        _shoppingOrder.OrderCustID = _customerBL.GetID(userEmail, userPass);
                        Console.WriteLine("Customer ID : " + _shoppingOrder.OrderCustID);

                    }while(_shoppingOrder.OrderCustID == 0);
             
                    //Adding StoreID
                    _shoppingOrder.OrderStoreID = _productInfo.StoreID;

                    //Adding Date Time of Order
                    DateTime OrderDate = DateTime.Now;
                    _shoppingOrder.OrderDate = OrderDate.ToString("MM/dd/yyyy");

                    // //Adding Order Total
                    // _shoppingOrder.OrderTotal = OrderTotal;

                    //Adding Line Items Cart to Order
                    _shoppingOrder.OrderLineItems = new List<LineItems>();
                    _shoppingOrder.OrderLineItems = _shoppingCart;
                    _shoppingOrder.OrderStatus = "PROCESSING";


                    //Add Order to Repo
                    Console.WriteLine("Attempting to Add Order ........");
                    _orderBL.AddOrders(_shoppingOrder); 
                    

                    //Find the OrderID
                    List<Orders> getcount = new List<Orders>();
                    getcount = _orderBL.GetAllOrders();
                    int OrderID = getcount.Count();
                    Console.WriteLine("Your Order ID is : " + OrderID);
                    Console.WriteLine("Order Added. Press Enter");
                    Console.ReadLine();
                    
                    //Display Items Ordered
                    Console.Clear();
                    Console.WriteLine("*******************************");
                    Console.WriteLine("These were the Items Ordered");
                    _orderBL.DisplayCart(_shoppingOrder.OrderLineItems);
                    Console.WriteLine("*******************************");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();

                    //******************HERE

                    //Add Order ID to ALL LineItems
                    foreach(LineItems item in _shoppingCart)
                    {
                        item.OrderID = OrderID;
                    }

                    //Add All LineItems to Repo
                    foreach(LineItems item in _shoppingCart)
                    {
                        _orderBL.AddLineItems(item);
                        Console.WriteLine($"Added to DB : {item}");
                        Console.Clear();
                    }
                    
                    //Update Inventory
                    //Set IDs, Pull Inventory Item Info, subtract quantity, reupdate Item totals in DB
                    //Throws exceptions when needed
                    foreach(LineItems item in _shoppingCart)
                    {
                        //New Inventory object every loop
                        Inventory inventoryobj1 = new Inventory();
                        //Populating Fields
                        inventoryobj1.StoreID = item.StoreID;
                        inventoryobj1.ProductID = item.ProductID;
                        //Calculate Quantity to subtract in a Variable
                        int subtractvalue = item.ProductQuantity;
                        Console.WriteLine($"Inventory will be subtracted by: {subtractvalue}");
                        //Second Inventory object to hold the actual Row Record We Need to Manipulate
                        Inventory inventoryobj2 = new Inventory();
                        inventoryobj2 = _inv.FindItemLevel(inventoryobj1.StoreID, inventoryobj1.ProductID);
                        Console.WriteLine($"Inventory previously held : {inventoryobj2.ProductQuantity}");
                        //Subtract the Value From the Quantity
                        inventoryobj2.ProductQuantity -= subtractvalue;
                        Console.WriteLine($"Inventory will now have {inventoryobj2.ProductQuantity}");

                            if(inventoryobj2.ProductQuantity < 0)
                            {
                                Console.WriteLine($"We cannot fulfill your order. We are missing {inventoryobj2.ProductQuantity} units ");
                                Console.WriteLine("Press Enter to Continue");
                                Console.ReadLine();
                            }
                            else
                            {
                                _inv.UpdateInventory(inventoryobj2);
                                Console.WriteLine($"Inventory Item Now Added : {inventoryobj2}");
                                Console.WriteLine("Press Enter to Continue");
                                Console.ReadLine();
                            }
                    }
                }
                catch(InvalidDataException)
                {
                    Console.WriteLine("The Data could not be processed.");
                    Console.WriteLine("Please Try Again.");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                }
                _shoppingCart.Clear();
                _shoppingOrder.OrderTotal = 0;
                return "AddNewOrderMenu";
                    


                //Default Menu
                default:
                Log.Information("User has made an Invalid Selection");
                Console.WriteLine("You have made an Invalid Selection - Please Press Enter to Continue");
                Console.ReadLine();
                return "AddNewOrderMenu";
            }
        }
    }
}