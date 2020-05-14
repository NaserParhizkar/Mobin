using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RefahPardisAPI.Utilities;

namespace RefahPardisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [ValidateApiAttribute()]
        public IActionResult MyAction()
        {
            return Ok();
        }
    }


}