using StoreModel;
using StoreDL;

namespace StoreBL
{    public class ProductsBL : IProductsBL
    {

        private readonly ISqlpRepository _repo;
        public ProductsBL(ISqlpRepository p_repo)
        {
            _repo = p_repo;
        }


        public Products AddProducts(Products p_product)
        {
                return _repo.AddProducts(p_product);
        }


        public List<Products> GetAllProducts()
        {
            List<Products> listofproducts = _repo.GetAllProducts();
            return listofproducts;
        }

        
    }
}