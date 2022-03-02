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
            return _repo.AddOrders(p_order);
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

    }
}