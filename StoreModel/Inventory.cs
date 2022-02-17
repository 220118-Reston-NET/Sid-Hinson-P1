namespace StoreModel
{
    public class Inventory
    {
          public int WarehouseID { get; set; }
          public int StoreID { get; set;}
          public int ProductID { get; set; }
          public int ProductQuantity { get; set; }

        public Inventory()
        {
            WarehouseID = 0;
            StoreID = 0;
            ProductID = 0;
            ProductQuantity = 0;
        }
        
        public override string ToString()
        {
            return $"\nWarehouseID: {WarehouseID}\nStoreID: {StoreID}\nProductID: {ProductID}\nQuantity: {ProductQuantity}";
        }
    }
  
}