using StoreModel;
using StoreDL;

namespace StoreBL
{
    public class StoreFrontsBL : IStoreFrontsBL
    {
        private readonly ISqLsRepository _repo;
        public StoreFrontsBL(ISqLsRepository p_repo)
        {
            _repo = p_repo;
        }
        /// <summary>
        /// Add StoreFronts
        /// </summary>
        /// <param name="p_sfront"></param>
        /// <returns>StoreFront Object</returns>
        public StoreFronts AddStoreFronts(StoreFronts p_sfront)
        {
                Console.WriteLine("Adding Store Front............");
                return _repo.AddStoreFronts(p_sfront);
        }
        /// <summary>
        /// Search StoreFronts
        /// </summary>
        /// <param name="p_storeNumber"></param>
        /// <returns>list Storefronts</returns>
        public List<StoreFronts> SearchStoreFronts(int p_storeNumber) 
        {
            Console.WriteLine("Searching for Store Front Information ...........");
            List<StoreFronts> listofstorefronts = _repo.GetAllStoreFronts();
            return listofstorefronts
                    .Where(StoreFronts => StoreFronts.StoreID.Equals(p_storeNumber))
                    .ToList(); 
        }
        /// <summary>
        /// Gets All StoreFronts
        /// </summary>
        /// <returns></returns>
        public List<StoreFronts> GetAllStoreFronts()
        {
            List<StoreFronts> listofstorefronts = _repo.GetAllStoreFronts();
            return listofstorefronts;
        }
        /// <summary>
        /// Gets Store History
        /// </summary>
        /// <param name="p_store"></param>
        /// <returns></returns>
        public List<StoreFronts> GetStoreHist(int p_store)
        {
            return _repo.GetStoreHist(p_store);
        }
        
    }
}