using StoreBL;
using StoreModel;

namespace StoreUI
{

    public class AdminOrderMenu : IMenu
    {

        private IOrdersBL _ordBL;
        private ICustomersBL _custBL;
        private IStoreFrontsBL _storebl;
        public AdminOrderMenu(IOrdersBL p_ord, ICustomersBL p_cust, IStoreFrontsBL p_store)
        {
            _custBL = p_cust;
            _ordBL = p_ord;
            _storebl = p_store;
        }
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=          Menu : Order Administration         =");
            Console.WriteLine("================================================");
            Console.WriteLine("=       Check or Update Warehouse Products     =");     
            Console.WriteLine("================================================");
            Console.WriteLine("=[0] - Return to Main Menu");
            Console.WriteLine("=[1] - Check Order Status ");
            Console.WriteLine("=[2] - Change Order Status");
            Console.WriteLine("=[3] - Locate Customer Order by Cust/StoreID");
            Console.WriteLine("=[4] - Locate Customer ID Retrieval Tool");
            Console.WriteLine("=[5] - View All Orders for a StoreFront");
            Console.WriteLine("===============================================");

        }

        public string UserSelection()
        {
            Log.Information("User is inputting the Menu Selection");
            string userInput = Console.ReadLine();
            switch(userInput)
            {
                case "0":
                    Log.Information("User is selecting Store Main Menu");
                    return "StoreMainMenu";
                    
                case "1":
                    Log.Information("User is selecting Check Order Status");
                    Console.WriteLine("Please Enter the Order ID");
                    int p_ordID = Convert.ToInt32(Console.ReadLine());
                    Orders foundord = _ordBL.SearchOrdStat(p_ordID);
                    Console.Clear();
                    _ordBL.DisplayGraphic();
                    Console.WriteLine("The Follwing Order Was Found");
                    Console.WriteLine(foundord);
                    Console.WriteLine("Press Enter to Return to Order Admin");
                    Console.ReadLine();
                    return "AdminOrderMenu";




                case "2":
                    Log.Information("User is selecting Change Order Status");
                    Console.WriteLine("Please Enter the Order ID");
                    int p_oID = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    _ordBL.DisplayGraphic();
                    Console.WriteLine("===================================");
                    Console.WriteLine("=Please Enter the New Order Status=");
                    Console.WriteLine("===================================");
                    Console.WriteLine("=[1] - PROCESSING");
                    Console.WriteLine("=[2] - FULFILLED");
                    Console.WriteLine("=[3] - CANCELLED");
                    Console.WriteLine("===================================");
                    Console.WriteLine("=[4] - Exit this Menu");
                    Console.WriteLine("===================================");
                    string p_newos = Console.ReadLine();
                    switch(p_newos)
                    {   
                        case "1":
                        string answer1 = "PROCESSING";
                        _ordBL.UpdateOrdStat(p_oID, answer1);
                        Console.WriteLine("Order Updated");
                        Console.WriteLine("Press Enter to Continer");
                        Console.ReadLine();
                        return "AdminOrderMenu";
                        case "2":
                        string answer2 = "FULFILLED";
                        _ordBL.UpdateOrdStat(p_oID, answer2);
                        Console.WriteLine("Order Updated");
                        Console.WriteLine("Press Enter to Continer");
                        Console.ReadLine();
                        return "AdminOrderMenu";
                        case "3":
                        string answer3 = "CANCELLED";
                        _ordBL.UpdateOrdStat(p_oID, answer3);
                        Console.WriteLine("Order Updated");
                        Console.WriteLine("Press Enter to Continer");
                        Console.ReadLine();
                        return "AdminOrderMenu";
                        case "4":
                        return "AdminOrderMenu";
                        default:
                        Console.WriteLine("Invalid Selection.Press Enter to Continer");
                        Console.ReadLine();
                        return "AdminOrderMenu";

                    };


                case "3":
                    Log.Information("User is selecting Search for Customer Order");
                    Console.WriteLine("Please Enter a Customer ID");
                    int p_cID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please Enter a Store ID");
                    int p_sID = Convert.ToInt32(Console.ReadLine());
                    List<Orders> searchorder = _ordBL.SearchForOrderbyID(p_cID, p_sID);
                    if(searchorder.Any())
                    {
                        Console.Clear();
                        _ordBL.DisplayGraphic();
                        Console.WriteLine("The following orders were found:");
                        foreach(Orders ord in searchorder)
                        {
                            Console.WriteLine("********");
                            Console.WriteLine(ord);
                            Console.WriteLine("********");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Orders were found!");
                    }

                    Console.WriteLine("Press Enter to Return to Order Admin");
                    Console.ReadLine();
                    return "AdminOrderMenu";


                case "4":
                    Log.Information("User is selecting Search for Customer");
                    Console.WriteLine("Please enter Customer First Name:");
                    string p_f = Console.ReadLine();
                    p_f = p_f.ToUpper();
                    Console.WriteLine("Please enter Customer Last Name:");
                    string p_l = Console.ReadLine();
                    p_l = p_l.ToUpper();
                    Console.WriteLine("Please enter Customer City:");
                    string p_c = Console.ReadLine();
                    p_c = p_c.ToUpper();
                    Console.WriteLine("Please enter Customer State:");
                    string p_s = Console.ReadLine();
                    p_s = p_s.ToUpper();
                    List<Customers> searchcust = _custBL.SearchForCustomers(p_f,p_l,p_c,p_s);
                    if(searchcust.Any())
                    {
                        Console.Clear();
                        _ordBL.DisplayGraphic();
                        Console.WriteLine("The following customers were found:");
                        foreach(Customers cust in searchcust)
                        {
                            Console.WriteLine(cust);
                            Console.WriteLine("The Found CustomerID is : " + cust.CustomerID);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Customer was found");
                    }

                    Console.WriteLine("Press Enter to Return to Order Admin");
                    Console.ReadLine();
                    return "AdminOrderMenu";


                case "5":
                    Log.Information("User is selecting View All Orders for a Store Front");
                    Console.WriteLine("Please Enter a Store ID");
                    int p_sCID = Convert.ToInt32(Console.ReadLine());
                    List<StoreFronts> findstoreorders = _storebl.GetCompStoreHist(p_sCID);
                    foreach(StoreFronts store in findstoreorders)
                    {
                        Console.WriteLine("******************");
                        Console.WriteLine("Store Order Information");
                        Console.WriteLine("StoreID          : " + store.StoreID);
                        Console.WriteLine("StoreAddress     : " + store.StoreAddress);
                        Console.WriteLine("StoreZipcode     : " + store.StoreZipCode);
                        Console.WriteLine("StoreState       : " + store.StoreState);
                        Console.WriteLine("StoreCity        : " + store.StoreCity);
                        Console.WriteLine("StoreOrderID     : " + store.OrderID);
                        Console.WriteLine("StoreOrderDate   : " + store.OrderDate);
                        Console.WriteLine("StoreOrderTotal  : " + store.OrderTotal);
                        Console.WriteLine("StoreOrderStatus : " + store.OrderStatus);
                        Console.WriteLine("Order - CustID   : " + store.CustID);
                        Console.WriteLine("Order - CustLast : " + store.CLastName);
                        Console.WriteLine("******************");

                    }
                    Console.WriteLine("Press Enter to Continer");
                    Console.ReadLine();
                    return "AdminOrderMenu";



                default :
                    Console.WriteLine("Invalid Selection. Press Enter to Continue");
                    Console.ReadLine();
                    return "AdminOrderMenu";
            }







    
        }
    }


}