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

        //POST AddStoreFronts
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
        // // GET: api/StoreFronts
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // // GET: api/StoreFronts/5
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // // POST: api/StoreFronts
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }

        // // PUT: api/StoreFronts/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE: api/StoreFronts/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
