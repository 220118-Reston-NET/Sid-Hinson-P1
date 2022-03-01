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
        
        
        [HttpPost("AddCustomers")]
        public IActionResult AddCustomers([FromQuery] Customers p_cust)
        {
            try
            {
                Log.Information("User is adding a Customer");
                return Created("Success", _custbl.AddCustomers(p_cust));
            }
            catch (System.Exception)
            {
                Log.Information("Bad Request to User");
                return BadRequest();
            }

        }

        
        [HttpGet("SearchCustomers")]
        public IActionResult GetCustomersByName(string CFirstName, string CLastName)
        {
            
            try
            {
                Log.Information("Displaying Customers by Name to User");
                return Ok(_custbl.SearchCustomersByName(CFirstName.ToUpper(), CLastName.ToUpper()));
            }
            catch (SqlException)
            {
                Log.Information("Displaying Customers Not Found to User");
                return NotFound();
            }
        }

    }
}
