using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class SearchOrdersCMenu : IMenu
    {
        private int p_custID;
        private IOrdersBL _ordBL;
        private ICustomersBL _custbl;
        private IProductsBL _prodBL;
        public SearchOrdersCMenu(IOrdersBL p_ordBL, ICustomersBL p_custbl, IProductsBL p_prodBL)
        {
            _ordBL = p_ordBL;
            _custbl = p_custbl;
            _prodBL = p_prodBL;
        }
        public void MenuDisplay()
        {   
            Console.Clear();
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
            Console.WriteLine("      ============================================");
            Console.WriteLine("      =    Menu : View Orders & Orders History   =");
            Console.WriteLine("      ============================================");
            Console.WriteLine("      =              Select Option :             =");
            Console.WriteLine("      = [0] - Exit Search                        =");
            Console.WriteLine("      = [1] - Find Current Order                 =");
            Console.WriteLine("      = [2] - Find Fulfilled Orders              =");
            Console.WriteLine("      = [3] - Find Comprehensive Orders History  =");
            Console.WriteLine("==========================================================");
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
        }

        public string UserSelection()
        {
            string UserInput = Console.ReadLine();
            switch (UserInput)
            {
                case "0":
                    Log.Information("User is selecting Store Main Menu");
                    return "StoreMainMenu";

                case "1":
                    Log.Information("User is selecting view Current Orders");

                    //Get Inputs
                    Console.WriteLine("Please Enter Your Email Address");
                    string p_emailc = Console.ReadLine();
                    p_emailc = p_emailc.ToUpper();

                    Console.WriteLine("Please Enter Your Password");
                    string p_passc = Console.ReadLine();

                    // Verify GetID & Display ID
                    p_custID = _custbl.GetID(p_emailc, p_passc);
                    Console.WriteLine($"Your Customer ID is {p_custID}");
                    Console.WriteLine("Please Press Enter to Continue");
                    Console.ReadLine();
                    string p_statusc = "PROCESSING";


                    //Search for Current Order
                    List<Orders> listofordersc = _ordBL.SearchOrders(p_custID,p_statusc);


                    //List Information About Order if possible
                    if(listofordersc.Any())
                    {
                        foreach (Orders orders in listofordersc)
                        {   Console.Clear();
                            _ordBL.DisplayGraphic();
                            Console.WriteLine("Here are your Current Orders :");
                            Console.WriteLine(orders);
                            Console.WriteLine("Please Press Enter to Continue");
                            Console.ReadLine();
                            List<LineItems> listoflinec = _ordBL.SearchLineItems(orders.OrderID);
                            foreach (LineItems lineitem in listoflinec)
                            {
                                Console.WriteLine("Here Were Your Associated Line Items :");
                                Console.WriteLine(lineitem);
                                Console.WriteLine("Please Press Enter to Continue");
                                Console.ReadLine();
                                List<Products> listofproductc = _prodBL.SearchProductsID(lineitem.ProductID);
                                    foreach (Products product in listofproductc)
                                    {
                                        Console.WriteLine("Here is Associated Line Item Product Information :");
                                        Console.WriteLine(product);
                                        Console.WriteLine("Please Press Enter to Continue");
                                        Console.ReadLine();
                                    }
                            }

                        }
                        Console.Clear();
                        _ordBL.DisplayGraphic();
                        Console.WriteLine("Retro Barbarian STRIVES for Order Accuracy. Please Press Enter to Continue");
                        Console.ReadLine();
                        return "SearchOrdersCMenu";
                    }
                    else
                    {
                        //Confirm to User no result
                        Console.Clear();
                        _ordBL.DisplayGraphic();
                        Console.WriteLine("Your search did not return any results. Please try again");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        return "SearchOrdersCMenu";
                    }

                case "2":
                    Log.Information("User is selecting view Fulfilled Orders");

                    //Get Inputs
                    Console.WriteLine("Please Enter Your Email Address");
                    string p_emailf = Console.ReadLine();
                    p_emailf = p_emailf.ToUpper();

                    Console.WriteLine("Please Enter Your Password");
                    string p_passf = Console.ReadLine();
                    string p_statusf = "FULFILLED";
                    // Verify GetID & Display ID
                    p_custID = _custbl.GetID(p_emailf, p_passf);
                    Console.WriteLine($"Your Customer ID is {p_custID}");
                    Console.WriteLine("Please Press Enter to Continue");
                    Console.ReadLine();

                    //Search for Fulfilled Order History
                    List<Orders> listofordersf = _ordBL.SearchOrders(p_custID, p_statusf);
                    if(listofordersf.Any())
                    {
                        foreach (Orders orders in listofordersf)
                        {   Console.Clear();
                            _ordBL.DisplayGraphic();
                            Console.WriteLine("Here are your Current Orders :");
                            Console.WriteLine(orders);
                            Console.WriteLine("Please Press Enter to Continue");
                            Console.ReadLine();
                            List<LineItems> listoflinec = _ordBL.SearchLineItems(orders.OrderID);
                            foreach (LineItems lineitem in listoflinec)
                            {   
                                Console.WriteLine("Here Were Your Associated Line Items :");
                                Console.WriteLine(lineitem);
                                Console.WriteLine("Please Press Enter to Continue");
                                Console.ReadLine();
                                List<Products> listofproductc = _prodBL.SearchProductsID(lineitem.ProductID);
                                    foreach (Products product in listofproductc)
                                    {   
                                        Console.WriteLine("Here is Associated Line Item Product Information :");
                                        Console.WriteLine(product);
                                        Console.WriteLine("Please Press Enter to Continue");
                                        Console.ReadLine();

                                    }
                            }
                        }
                        Console.Clear();
                        _ordBL.DisplayGraphic();
                        Console.WriteLine("Retro Barbarian STRIVES for Order Accuracy. Please Press Enter to Continue");
                        Console.ReadLine();
                        return "SearchOrdersCMenu";
                    }
                    else
                    {
                        //Confirm to User no result
                        Console.Clear();
                        _ordBL.DisplayGraphic();
                        Console.WriteLine("Your search did not return any results. Please try again");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        return "SearchOrdersCMenu";
                    }
                case "3":
                Log.Information("User is selecting view Comprehensive Order History");
                Log.Information("User is selecting view Current Orders");

                //Get Inputs
                Console.WriteLine("Please Enter Your Email Address");
                string p_emailc2 = Console.ReadLine();
                p_emailc2 = p_emailc2.ToUpper();

                Console.WriteLine("Please Enter Your Password");
                string p_passc2 = Console.ReadLine();

                // Verify GetID & Display ID
                p_custID = _custbl.GetID(p_emailc2, p_passc2);
                Console.WriteLine($"Your Customer ID is {p_custID}");
                Console.WriteLine("Please Press Enter to Continue");
                Console.ReadLine();

                Console.WriteLine("This is your Comprehensive Order history");
                List<Orders> comporders = _ordBL.GetCompOrderHist(p_custID);
                foreach(Orders order in comporders)
                {
                    Console.WriteLine("******************");
                    Console.WriteLine("Order Information:");
                    Console.WriteLine("OrderID      : " + order.OrderID);
                    Console.WriteLine("CustID       : " + order.OrderCustID);
                    Console.WriteLine("StoreID      : " + order.OrderStoreID);
                    Console.WriteLine("OrderDate    : " + order.OrderDate);
                    Console.WriteLine("OrderTotal   : " + order.OrderTotal);
                    Console.WriteLine("OrderStatus  : " + order.OrderStatus);
                    Console.WriteLine("ProductID    : " + order.ProductID);
                    Console.WriteLine("ProductQuant : " + order.ProductQuantity);
                    Console.WriteLine("ProductName  : " + order.ProductName);
                    Console.WriteLine("CustLastName : " + order.CLastName);
                    Console.WriteLine("*****************");
                }
                Console.WriteLine("Press Enter");
                Console.ReadLine();
                return "SearchOrdersCMenu";


                default:
                    Console.WriteLine("Invalid Selection");
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "SearchOrdersCMenu";
            }
        }
    }
}