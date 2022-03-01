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

        private ICustomersBL _custbl;

        public OrdersController(IOrdersBL ordbl, ICustomersBL custbl)
        {
            _ordbl = ordbl;
            _custbl = custbl;
        }

        
        [HttpPost("AddOrders")]
        public IActionResult AddOrders([FromBody] Orders p_ord)
        {
            try
            {
                return Created("Success", _ordbl.AddOrders(p_ord));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

        }


        [HttpGet("GetOrdersHistory")]
        public IActionResult GetOrdersHistory(int p_ordCustID, string email, string pass)
        {
            if(_custbl.isAdmin(email,pass))
            {
                try
                {
                    return Ok(_ordbl.GetOrdersHistory(p_ordCustID));
                }
                catch (SqlException)
                {
                    return NotFound();
                }
            }
            else
            {
                return StatusCode(401, "No access allowed for this User");
            }
        }

        
        [HttpGet("GetDetailedOrderHistory")]
        public IActionResult GetOrderHistory(int p_ordID, string email, string pass)
        {
            if(_custbl.isAdmin(email,pass))
            {
                try
                {
                    return Ok(_ordbl.GetOrderHistory(p_ordID));
                }
                catch (SqlException)
                {
                    return NotFound();
                }
            }
            else
            {
                return StatusCode(401, "No access allowed for this User");
            }
        }

        [HttpGet("GetOrderHistoryLocation")]
        public IActionResult GetOrderHistoryLocation(int p_storeID, string email, string pass)
        {
            if(_custbl.isAdmin(email,pass))
            {
                try
                {
                    return Ok(_ordbl.SearchStoreOrders(p_storeID));
                }
                catch (SqlException)
                {
                    return NotFound();
                }
            }
            else
            {
                return StatusCode(401, "No access allowed for this User");
            }


        }
    
    }
}
