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

        private readonly IProductsBL _prodbl;
        private readonly ICustomersBL _custbl;

        public ProductsController(IProductsBL prodbl, ICustomersBL custbl)
        {
            _prodbl = prodbl;
            _custbl = custbl;
        }

        /// <summary>
        /// Adds Products
        /// </summary>
        /// <param name="p_prod"></param>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        /// <returns>Product object</returns>
        [HttpPost("AddProducts")]
        public IActionResult AddProducts([FromQuery] Products p_prod, string email, string pass)
        {
            Log.Information("User is entering Credentials.");
            if(_custbl.isAdmin(email,pass))
            {
                try
                {
                    Log.Information("User is Adding a Product");
                    return Created("Success", _prodbl.AddProducts(p_prod));
                }
                catch (System.Exception)
                {
                    Log.Information("User has made a bad request");
                    return BadRequest();
                }
            }
            else
            {
                Log.Information("Access is not allowed for The User");
                return StatusCode(401, "No access allowed for this User");
            }
        }

    }
}
