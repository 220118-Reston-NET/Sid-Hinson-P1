using StoreModel;
using StoreDL;

namespace StoreBL
{
    public class InventoryBL : IInventoryBL
    {
        private ISQL_InvRepository _repo;
        public InventoryBL(ISQL_InvRepository p_repo)
        {
            _repo = p_repo;
        }
        public Inventory AddInventory(Inventory p_inv)
        {
            List<Inventory> listofInventory = _repo.GetAllInventory();
            Console.WriteLine("Adding Inventory............");
            return _repo.AddInventory(p_inv);
        }

        public Inventory FindItemLevel(int p_storeID, int p_prodID)
        {
            List<Inventory> listofInventory = _repo.GetAllInventory();
            Inventory FoundItem = new Inventory();
            FoundItem = GetAllInventory().Where(inv => inv.StoreID.Equals(p_storeID) & inv.ProductID.Equals(p_prodID)).First();
            return FoundItem;
        }

        public Inventory UpdateInventory(Inventory p_inv)
        {
            return _repo.UpdateInventory(p_inv);
        }

        public List<Inventory> GetAllInventory()
        {
            List<Inventory> listofinventory = _repo.GetAllInventory();
            return listofinventory;
        }
        
    }
}