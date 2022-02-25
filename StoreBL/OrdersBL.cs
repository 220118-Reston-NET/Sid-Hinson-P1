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


        public List<Orders> SearchStoreOrders(int p_storeID, string p_status)
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            return listoforders
                    .Where(Orders => Orders.OrderStoreID.Equals(p_storeID))
                    .Where(Orders => Orders.OrderStatus.Contains(p_status))
                    .ToList(); //ToList method converts into return List collection
        }



        public List<Orders> SearchOrders(int p_custID, string p_status)
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            return listoforders
                    .Where(Orders => Orders.OrderCustID.Equals(p_custID))
                    .Where(Orders => Orders.OrderStatus.Contains(p_status))
                    .ToList(); //ToList method converts into return List collection
        }


        public List<Orders> SearchForOrderbyID(int p_custID, int p_storeID)
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            return listoforders
                    .Where(Orders => Orders.OrderCustID.Equals(p_custID))
                    .Where(Orders => Orders.OrderStatus.Equals(p_storeID))
                    .ToList(); //ToList method converts into return List collection
        }



        public Orders SearchOrdStat(int p_ordID)
        {
            Orders foundord = new Orders();
            List<Orders> listoforders = _repo.GetAllOrders();
            foundord = GetAllOrders().Where(order => order.OrderID.Equals(p_ordID)).First();
            return foundord;
        }



        public void UpdateOrdStat(int p_ordID, string p_stat)
        {
            _repo.UpdateOrdStat(p_ordID, p_stat);
        }



        public List<Orders> GetOrdersHistory(int p_custID)
        {
            return _repo.GetOrdersHistory(p_custID);
        }

        public Orders GetOrderHistory(int p_ordID)
        {
            return _repo.GetOrderHistory(p_ordID);
        }

        public LineItems AddLineItems(LineItems p_line)
        {
            List<LineItems> listoflineitems = _repo.GetAllLineItems();
            return _repo.AddLineItems(p_line);
        }


        public List<LineItems> SearchLineItems(int p_orderID)
        {
            List<LineItems> listoflineitems = _repo.GetAllLineItems();
            return listoflineitems
                    .Where(LineItems => LineItems.OrderID.Equals(p_orderID))
                    .ToList(); //ToList method converts into return List collection
        }


        public LineItems AddItemFields(int p_prodID, int p_prodQuant,int p_storeID, double p_price)
        {
            LineItems p_lineItem = new LineItems();
            p_lineItem.ProductID = p_prodID;
            p_lineItem.ProductQuantity = p_prodQuant;
            p_lineItem.StoreID = p_storeID;
            p_lineItem.Price = p_price;
            return p_lineItem;
        }

    }
}