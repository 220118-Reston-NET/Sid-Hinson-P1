namespace StoreModel
{
    public class Products
    {
        public int ProductID { get; set; }
        public int StoreID { get; set; }
        public string ProductName { get; set; }
        public string ProductCompany { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }

        //Default Constructor
        public Products()
        {
            StoreID = 0;
            ProductName = "";
            ProductCompany ="";
            ProductPrice = 0;
            ProductDescription = "";
            ProductCategory = "";
        }

    public override string ToString()
    {
      return $"Product Id: {ProductID}\nStore Number: {StoreID}\nName: {ProductName}" +
      $"\nPrice: {ProductPrice}\nDes: {ProductDescription}\nCategory: {ProductCategory}" +
      $"\nCompany: {ProductCompany}";
    }

    }

}