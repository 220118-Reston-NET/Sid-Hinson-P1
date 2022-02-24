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
    public class ProductsController : ControllerBase
    {

        private IProductsBL _prodbl;

        public ProductsController(IProductsBL prodbl)
        {
            _prodbl = prodbl;
        }

        //POST ADD PRODUCTS
        [HttpPost("AddProducts")]
        public IActionResult AddProducts([FromQuery] Products p_prod)
        {
            try
            {
                return Created("Success", _prodbl.AddProducts(p_prod));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

        }

        // // GET: api/Products
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // // GET: api/Products/5
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // // POST: api/Products
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }

        // // PUT: api/Products/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE: api/Products/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
