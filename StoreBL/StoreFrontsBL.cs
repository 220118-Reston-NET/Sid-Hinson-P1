using StoreModel;
using StoreDL;

namespace StoreBL
{
    public class StoreFrontsBL : IStoreFrontsBL
    {
        private ISQLSRepository _repo;
        public StoreFrontsBL(ISQLSRepository p_repo)
        {
            _repo = p_repo;
        }

        
        public StoreFronts AddStoreFronts(StoreFronts p_front)
        {
                Console.WriteLine("Adding Store Front............");
                return _repo.AddStoreFronts(p_front);
        }

        public List<StoreFronts> SearchStoreFronts(int p_storeID) 
        {
            Console.WriteLine("Searching for Store Front Information ...........");
            List<StoreFronts> listofstorefronts = _repo.GetAllStoreFronts();
            return listofstorefronts
                    .Where(StoreFronts => StoreFronts.StoreID.Equals(p_storeID))
                    .ToList(); 
        }


        public List<StoreFronts> GetAllStoreFronts()
        {
            List<StoreFronts> listofstorefronts = _repo.GetAllStoreFronts();
            return listofstorefronts;
        }


        public List<StoreFronts> GetStoreHist(int p_storeID)
        {
            return _repo.GetStoreHist(p_storeID);
        }
        
    }
}