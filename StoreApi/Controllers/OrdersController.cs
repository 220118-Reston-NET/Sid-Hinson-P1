using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class OrdersController : ControllerBase
    {

        private IOrdersBL _ordbl;

        public OrdersController(IOrdersBL ordbl)
        {
            _ordbl = ordbl;
        }




        [HttpGet("GetFullOrdersHistory")]
        public IActionResult GetComprehensiveOrderHistory(int p_customerID)
        {
             try
            {
                return Ok(_ordbl.GetCompOrderHist(p_customerID));
            }
            catch (SqlException)
            {
                return NotFound();
            }
        }

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
