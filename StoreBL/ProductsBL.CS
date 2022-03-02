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
        /// <summary>
        /// Adds Products
        /// </summary>
        /// <param name="p_product"></param>
        /// <returns>Product Object</returns>
        public Products AddProducts(Products p_product)
        {
                return _repo.AddProducts(p_product);
        }
        /// <summary>
        /// Gtes All Products
        /// </summary>
        /// <returns>List of Products</returns>
        public List<Products> GetAllProducts()
        {
            List<Products> listofproducts = _repo.GetAllProducts();
            return listofproducts;
        }

    }
}