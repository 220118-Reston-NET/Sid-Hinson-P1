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