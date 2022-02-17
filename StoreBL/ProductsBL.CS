using StoreModel;
using StoreDL;

namespace StoreBL
{    public class ProductsBL : IProductsBL
    {

        private ISQL_PRepository _repo;
        public ProductsBL(ISQL_PRepository p_repo)
        {
            _repo = p_repo;
        }

        public Products AddProducts(Products p_product)
        {
                return _repo.AddProducts(p_product);

        }
        public List<Products> SearchProductsComp(string p_productComp) 
        {
            Console.WriteLine("Searching for Product ...........");
            List<Products> listofproducts = _repo.GetAllProducts();
            return listofproducts
                    .Where(Products => Products.ProductCompany.Contains(p_productComp))
                    .ToList(); 
        }
        public List<Products> SearchProductsCat(string p_productCat) 
        {
            Console.WriteLine("Searching for Product ...........");
            List<Products> listofproducts = _repo.GetAllProducts();
            return listofproducts
                    .Where(Products => Products.ProductCategory.Contains(p_productCat))
                    .ToList(); 
        }

        public List<Products> SearchProductsCat(string p_productCat, int p_storeID) 
        {
            Console.WriteLine("Searching for Product ...........");
            List<Products> listofproducts = _repo.GetAllProducts();
            return listofproducts
                    .Where(Products => Products.ProductCategory.Contains(p_productCat))
                    .Where(Products => Products.StoreID.Equals(p_storeID))
                    .ToList(); 
        }
        public List<Products> SearchProductsID(int p_productID)
        {
            List<Products> listofproducts = _repo.GetAllProducts();
            return listofproducts
                    .Where(Products => Products.ProductID.Equals(p_productID))
                    .ToList(); 
        }
        public List<Products> SearchProducts(string p_prodName, string p_prodComp, int p_StoreID)
        {
            Console.WriteLine("Searching for Product ...........");
            List<Products> listofproducts = _repo.GetAllProducts();
            return listofproducts
                    .Where(Products => Products.ProductName.Contains(p_prodName))
                    .Where(Products => Products.ProductCompany.Contains(p_prodComp))
                    .Where(Products => Products.StoreID.Equals(p_StoreID))
                    .ToList(); 
        }
        public Products SearchForProduct(string p_productName, int p_productStoreID)
        {
            Products getprod = new Products();
            List<Products> listofproducts = _repo.GetAllProducts();
            getprod = GetAllProducts().Where(p => p.ProductName.Contains(p_productName) & p.StoreID.Equals(p_productStoreID)).First();
            return getprod;
        }
        public double GetPrice(int p_productID)
        {
            double Price = 0;
            List<Products> listofproducts = _repo.GetAllProducts();
            for(int i = 0; i < listofproducts.Count; i++)
            {
                if(listofproducts[i].ProductID.Equals(p_productID))
                {
                    Price = listofproducts[i].ProductPrice;
                }
            }
            return Price;
        }
        public int GetID(string p_prodName, string p_prodComp, int p_StoreID)
        {   
            int ProdID = 0;
            List<Products> listofproducts = _repo.GetAllProducts();
            for(int i = 0; i < listofproducts.Count; i++)
            {
                if(listofproducts[i].ProductName.Contains(p_prodName) & listofproducts[i].ProductCompany.Contains(p_prodComp) & listofproducts[i].StoreID.Equals(p_StoreID))
                {
                    ProdID = listofproducts[i].ProductID;    
                }
            }
            return ProdID;
        }
        public List<Products> GetAllProducts()
        {
            List<Products> listofproducts = _repo.GetAllProducts();
            return listofproducts;
        }
    }
}