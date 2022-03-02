using StoreModel;
using StoreDL;

namespace StoreBL
{
    public class InventoryBL : IInventoryBL
    {
        private readonly ISqlInvRepository _repo;
        public InventoryBL(ISqlInvRepository p_repo)
        {
            _repo = p_repo;
        }

        /// <summary>
        /// Adds Inventory
        /// </summary>
        /// <param name="p_inv"></param>
        /// <returns>Inventory Object</returns>
        public Inventory AddInventory(Inventory p_inv)
        {
            Console.WriteLine("Adding Inventory............");
            return _repo.AddInventory(p_inv);
        }

        /// <summary>
        /// Searches Location Inventory
        /// </summary>
        /// <param name="p_storeID"></param>
        /// <returns>A List</returns>
        public List<Inventory> SearchLocationInventory(int p_storeID)
        {
            List<Inventory> listofInventory = _repo.GetAllInventory();
            return listofInventory
                    .Where(Inventory => Inventory.StoreID.Equals(p_storeID))
                    .ToList(); //ToList method converts into return List collection
        }

        /// <summary>
        /// Updates Inventory
        /// </summary>
        /// <param name="p_inv"></param>
        /// <returns>An inv object</returns>
        public Inventory UpdateInventory(Inventory p_inv)
        {
            return _repo.UpdateInventory(p_inv);
        }


        /// <summary>
        /// Gets All Inventory
        /// </summary>
        /// <returns></returns>
        public List<Inventory> GetAllInventory()
        {
            List<Inventory> listofinventory = _repo.GetAllInventory();
            return listofinventory;

        }
         
    }
}