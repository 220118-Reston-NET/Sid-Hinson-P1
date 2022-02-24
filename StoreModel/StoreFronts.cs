
namespace StoreModel
{

    public class StoreFronts
    {
        
        public int StoreID { get; set; }
        public string StoreZipCode { get; set; }
        public string StoreState { get; set; }
        public string StoreAddress { get; set; }
        public string StoreCity { get; set; }
        

        //Default Class Constructor
        public StoreFronts()
        {
            StoreAddress = "";
            StoreZipCode = "";
            StoreState = "";
            StoreCity = "";
        }

        public override string ToString()
        {
            return $"Store Number: {StoreID}\nStore Address: {StoreAddress}\nStore ZipCode: {StoreZipCode}" +
            $"\nStore City: {StoreCity}\nStore State: {StoreState}";
        }

    }

}