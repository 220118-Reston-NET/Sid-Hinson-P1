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

        public StoreFrontsController(IStoreFrontsBL storebl)
        {
            _storebl = storebl;
        }

        
        [HttpPost("AddStoreFronts")]
        public IActionResult AddStoreFronts([FromQuery] StoreFronts p_store)
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
    }
}
