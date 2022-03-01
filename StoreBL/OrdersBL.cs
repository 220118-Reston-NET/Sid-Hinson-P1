using StoreModel;
using StoreDL;

namespace StoreBL
{
    public class OrdersBL : IOrdersBL
    {
        private ISQLORepository _repo;
        public OrdersBL(ISQLORepository p_repo)
        {
            
            _repo = p_repo;
        }

        public Orders AddOrders(Orders p_order)
        {
            return _repo.AddOrders(p_order);
        }

        public List<Orders> GetAllOrders()
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            return listoforders;
        }

        public List<Orders> SearchStoreOrders(int p_storeID)
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            return listoforders
                    .Where(Orders => Orders.OrderStoreID.Equals(p_storeID))
                    .ToList(); //ToList method converts into return List collection
        }

        public List<Orders> GetOrdersHistory(int p_custID)
        {
            return _repo.GetOrdersHistory(p_custID);
        }

        public Orders GetOrderHistory(int p_ordID)
        {
            return _repo.GetOrderHistory(p_ordID);
        }

        public List<LineItems> GetAllLineItems()
        {
            List<LineItems> listofline = _repo.GetAllLineItems();
            return listofline;
        }

        public LineItems AddLineItems(LineItems p_line)
        {
            return _repo.AddLineItems(p_line);
        }

    }
}