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

        
        public StoreFronts AddStoreFronts(StoreFronts p_sfront)
        {
                Console.WriteLine("Adding Store Front............");
                return _repo.AddStoreFronts(p_sfront);
        }

        public List<StoreFronts> SearchStoreFronts(int p_storeNumber) 
        {
            Console.WriteLine("Searching for Store Front Information ...........");
            List<StoreFronts> listofstorefronts = _repo.GetAllStoreFronts();
            return listofstorefronts
                    .Where(StoreFronts => StoreFronts.StoreID.Equals(p_storeNumber))
                    .ToList(); 
        }


        public List<StoreFronts> GetAllStoreFronts()
        {
            List<StoreFronts> listofstorefronts = _repo.GetAllStoreFronts();
            return listofstorefronts;
        }


        public List<StoreFronts> GetStoreHist(int p_store)
        {
            return _repo.GetStoreHist(p_store);
        }
        
    }
}