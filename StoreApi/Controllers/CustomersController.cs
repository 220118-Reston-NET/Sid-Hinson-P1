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
    public class CustomersController : ControllerBase
    {
        private ICustomersBL _custbl;
        public CustomersController(ICustomersBL p_custbl)
        {
            _custbl = p_custbl;
        }
        
        //POST ADD CUSTOMERS
        [HttpPost("AddCustomers")]
        public IActionResult AddCustomers([FromQuery] Customers p_cust)
        {
            try
            {
                return Created("Success", _custbl.AddCustomers(p_cust));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

        }

        // GET: api/SearchCustomers
        [HttpGet("SearchCustomers")]
        public IActionResult GetCustomersByName(string CFirstName, string CLastName)
        {
            // 
            try
            {
                // return "value";
                return Ok(_custbl.SearchCustomersByName(CFirstName.ToUpper(), CLastName.ToUpper()));
            }
            catch (SqlException)
            {
                
                return NotFound();
            }
        }

    }
}
