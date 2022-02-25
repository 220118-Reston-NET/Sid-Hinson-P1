using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreModel;

namespace StoreApi.Controllers
{
    [Route("store-api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {

        private IInventoryBL _invbl;

        public InventoryController(IInventoryBL invbl)
        {
            _invbl = invbl;
        }

        //POST AddInventory
        [HttpPost("AddInventory")]
        public IActionResult AddInventory([FromQuery] Inventory p_inv)
        {
            try
            {
                return Created("Success", _invbl.AddInventory(p_inv));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

        }

        //PUT UpdateInventory
        [HttpPut("UpdateInventory")]
        public IActionResult UpdateInventory([FromQuery] Inventory p_inv)
        {
            try
            {
                return Ok(_invbl.UpdateInventory(p_inv));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

        }


        // // GET: api/Inventory
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // // GET: api/Inventory/5
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // // POST: api/Inventory
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }

        // // PUT: api/Inventory/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE: api/Inventory/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
