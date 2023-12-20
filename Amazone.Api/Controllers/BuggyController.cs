using Amazon.Repository.Context;
using Amazone.Api.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Amazone.Api.Controllers
{
 
    public class BuggyController : BaseSApiController
    {
        private readonly StoreContext _dbcontext;

        public BuggyController(StoreContext dbcontext)
        {
           _dbcontext = dbcontext;
        }
        [HttpGet("NotFound")]
        public ActionResult IGetNotfound() 
        {
            var product = _dbcontext.products.Find(100);
            if(product is null)return NotFound(new ApiResponse (404));
            return Ok(product);
        }
        [HttpGet("servererror")]
        public ActionResult serrvererror() 
        {
            var product = _dbcontext.products.Find(100);
            if (product is null) return NotFound(new ApiResponse(500));
            var productopreturn = product.ToString();
            return Ok(productopreturn); 
        }
        [HttpGet("badrequest")]
        public ActionResult getbadrequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badreques/{Id}")]
        public ActionResult GetbadeREquest(int id) 
        {
            return Ok();
        }
    }
}
