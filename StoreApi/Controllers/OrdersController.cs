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
        public IActionResult GetOrdersHistory(int p_ordCustID)
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

        
        [HttpGet("GetDetailedOrderHistory")]
        public IActionResult GetOrderHistory(int p_ordID)
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

        [HttpGet("GetOrderHistoryLocation")]
        public IActionResult GetOrderHistoryLocation(int p_storeID)
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
    
    }
}
