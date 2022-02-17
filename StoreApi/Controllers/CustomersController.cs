using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomersBL _custbl;
        public CustomersController(ICustomersBL p_custbl)
        {
            _custbl = p_custbl;
        }

        // GET: api/Customers
        [HttpGet]
        public IActionResult GetAllCustomers()
        {

            try
            {
                return Ok(_custbl.GetAllCustomers());
            }
            catch (SqlException)
            {
                return NotFound();
            }
            
        }

        // // GET: api/Customers
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
