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
    [Route("orders-api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private IOrdersBL _ordbl;

        public OrdersController(IOrdersBL ordbl)
        {
            _ordbl = ordbl;
        }


        // // GET: api/Orders
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // // GET: api/Orders/5
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // // POST: api/Orders
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }

        // // PUT: api/Orders/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE: api/Orders/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
