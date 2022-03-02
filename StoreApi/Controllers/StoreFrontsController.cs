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

        private readonly IStoreFrontsBL _storebl;
        private readonly ICustomersBL _custbl;

        public StoreFrontsController(IStoreFrontsBL storebl, ICustomersBL custbl)
        {
            _storebl = storebl;
            _custbl = custbl;
        }

        /// <summary>
        /// Adds StoreFronts
        /// </summary>
        /// <param name="p_store"></param>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        /// <returns>StoreFront Object</returns>
        [HttpPost("AddStoreFronts")]
        public IActionResult AddStoreFronts([FromQuery] StoreFronts p_store, string email, string pass)
        {
            Log.Information("User is entering Credentials.");
            if(_custbl.isAdmin(email,pass))
            {
                try
                {
                    Log.Information("User is Adding a StoreFront");
                    return Created("Success", _storebl.AddStoreFronts(p_store));
                }
                catch (System.Exception)
                {
                    Log.Information("Displaying Bad Request to User");
                    return BadRequest();
                }
            }
            else
            {
                Log.Information("Displaying User is Not Allowed");
                return StatusCode(401, "No access allowed for this User");
            }
        }
    }
}
