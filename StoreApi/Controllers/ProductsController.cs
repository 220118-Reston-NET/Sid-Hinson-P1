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
        private ICustomersBL _custbl;

        public ProductsController(IProductsBL prodbl, ICustomersBL custbl)
        {
            _prodbl = prodbl;
            _custbl = custbl;
        }

        
        [HttpPost("AddProducts")]
        public IActionResult AddProducts([FromQuery] Products p_prod, string email, string pass)
        {
            if(_custbl.isAdmin(email,pass))
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
            else
            {
                return StatusCode(401, "No access allowed for this User");
            }
        }

    }
}
