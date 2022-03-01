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

        private ICustomersBL _custbl;

        public InventoryController(IInventoryBL invbl, ICustomersBL custbl)
        {
            _invbl = invbl;
            _custbl =  custbl;
        }

        
        [HttpPost("AddInventory")]
        public IActionResult AddInventory([FromQuery] Inventory p_inv, string email, string pass)
        {

            if(_custbl.isAdmin(email,pass))
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
            else
            {
                return StatusCode(401, "No access allowed for this User");
            }

        }

        
        [HttpPut("UpdateInventory")]
        public IActionResult UpdateInventory([FromQuery] Inventory p_inv, string email, string pass)
        {
            if(_custbl.isAdmin(email,pass))
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
            else
            {
                return StatusCode(401, "No access allowed for this User");
            }

        }

        [HttpGet("SearchInventoryByLocation")]
        public IActionResult SearchLocationInventory([FromQuery] int p_storeID)
        {
            try
            {
                return Ok(_invbl.SearchLocationInventory(p_storeID));
            }
            catch (System.Exception)
            {
                
                return BadRequest();
            }


        }

    }
}
