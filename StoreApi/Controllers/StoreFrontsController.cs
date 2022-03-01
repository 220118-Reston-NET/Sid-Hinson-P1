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
    public class StoreFrontsController : ControllerBase
    {

        private IStoreFrontsBL _storebl;
        private ICustomersBL _custbl;

        public StoreFrontsController(IStoreFrontsBL storebl, ICustomersBL custbl)
        {
            _storebl = storebl;
            _custbl = custbl;
        }

        
        [HttpPost("AddStoreFronts")]
        public IActionResult AddStoreFronts([FromQuery] StoreFronts p_store, string email, string pass)
        {
            if(_custbl.isAdmin(email,pass))
            {
                try
                {
                    return Created("Success", _storebl.AddStoreFronts(p_store));
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
    }
}
