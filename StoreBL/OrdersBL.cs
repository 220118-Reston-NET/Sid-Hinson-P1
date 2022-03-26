using StoreModel;
using StoreDL;

namespace StoreBL
{
    public class OrdersBL : IOrdersBL
    {
        private readonly ISqloRepository _repo;
        public OrdersBL(ISqloRepository p_repo)
        {
            
            _repo = p_repo;
        }
        /// <summary>
        /// Adds Orders
        /// </summary>
        /// <param name="p_order"></param>
        /// <returns>Order object</returns>
        public Orders AddOrders(Orders p_order)
        {
            int counter = 0;
            foreach(var item in p_order.OrderLineItems)
            {
                if(CheckInventory(item.ProductID, item.ProductQuantity) == false)
                {
                    counter += 1;
                };
            }
            if(counter > 0)
            {
                Console.WriteLine("One or more of your items will exceed the database amounts. Please recheck your Order Totals or call us directly.");
            }
            else
            {
                return _repo.AddOrders(p_order);
            }

            return p_order;
        }
        /// <summary>
        /// Gets All Orders
        /// </summary>
        /// <returns>list orders</returns>
        public List<Orders> GetAllOrders()
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            return listoforders;
        }
        /// <summary>
        /// Searches Customer Orders
        /// </summary>
        /// <param name="p_ordCustID"></param>
        /// <returns>list orders</returns>
        public List<Orders> GetOrderHistoryLocation(int p_storeID)
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            return listoforders
                    .Where(Orders => Orders.OrderStoreID.Equals(p_storeID))
                    .ToList(); //ToList method converts into return List collection
        }
        /// <summary>
        /// Gets Orders History
        /// </summary>
        /// <param name="p_custID"></param>
        /// <returns>List Orders</returns>
        public List<Orders> GetOrdersHistory(int p_custID)
        {
            return _repo.GetOrdersHistory(p_custID);
        }
        /// <summary>
        /// Gets Orders History
        /// </summary>
        /// <param name="p_ordID"></param>
        /// <returns>list orders</returns>
        public Orders GetOrderHistory(int p_ordID)
        {
            return _repo.GetOrderHistory(p_ordID);
        }
        /// <summary>
        /// Gets All LineItems
        /// </summary>
        /// <returns></returns>
        public List<LineItems> GetAllLineItems()
        {
            List<LineItems> listofline = _repo.GetAllLineItems();
            return listofline;
        }
        /// <summary>
        /// Adds all LineItems
        /// </summary>
        /// <param name="p_line"></param>
        /// <returns>lineitem object</returns>
        public LineItems AddLineItems(LineItems p_line)
        {
            return _repo.AddLineItems(p_line);
        }
        /// <summary>
        /// Adds Inventory
        /// </summary>
        /// <param name="p_inv"></param>
        /// <returns>Inventory Object</returns>
        public Inventory AddInventory(Inventory p_inv)
        {
            Console.WriteLine("Adding Inventory............");
            return _repo.AddInventory(p_inv);
        }

        /// <summary>
        /// Searches Location Inventory
        /// </summary>
        /// <param name="p_storeID"></param>
        /// <returns>A List</returns>
        public List<Inventory> SearchLocationInventory(int p_storeID)
        {
            List<Inventory> listofInventory = _repo.GetAllInventory();
            return listofInventory
                    .Where(Inventory => Inventory.StoreID.Equals(p_storeID))
                    .ToList(); //ToList method converts into return List collection
        }

        /// <summary>
        /// Updates Inventory
        /// </summary>
        /// <param name="p_inv"></param>
        /// <returns>An inv object</returns>
        public Inventory UpdateInventory(Inventory p_inv)
        {
            return _repo.UpdateInventory(p_inv);
        }


        /// <summary>
        /// Gets All Inventory
        /// </summary>
        /// <returns></returns>
        public List<Inventory> GetAllInventory()
        {
            List<Inventory> listofinventory = _repo.GetAllInventory();
            return listofinventory;

        }
        /// <summary>
        /// Boolean Check if there is enough Inventory
        /// </summary>
        /// <param name="p_storeid"></param>
        /// <param name="prodid"></param>
        /// <param name="p_quant"></param>
        /// <returns></returns>
        public Boolean CheckInventory(int prodid, int p_quant)
        {
            Boolean isValid = false;
            List<Inventory> listofinventory = _repo.GetAllInventory();
            foreach(var item in listofinventory)
            {
                if(prodid ==item.ProductID && p_quant <= item.ProductQuantity)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }
            return isValid;
        }

    }
}