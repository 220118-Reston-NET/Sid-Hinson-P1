namespace StoreModel
{
    public class Orders
    {
       public int OrderID { get; set; }
       public int OrderCustID { get; set; }
       public int OrderStoreID { get; set; }
       public string OrderDate { get; set; }
       public string OrderStatus { get; set; }
       public List<LineItems> OrderLineItems { get; set; }
       public double OrderTotal { get; set; }

        public Orders()
        {
            OrderCustID = 0;
            OrderStoreID = 0;
            OrderDate = "";
            OrderStatus = "";
            OrderLineItems = new List<LineItems>(){ new LineItems() };
            OrderTotal = 0.00;
            
        
        }
        public override string ToString()
        {
            return $"OrderID: {OrderID}\nCustomerID: {OrderCustID}\nStoreID: {OrderStoreID}\nOrder Date: {OrderDate}" +
            $"\nOrderTotal: {OrderTotal}";
        }

    }
}