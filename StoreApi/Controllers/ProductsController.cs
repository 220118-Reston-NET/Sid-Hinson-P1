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

    }
}
