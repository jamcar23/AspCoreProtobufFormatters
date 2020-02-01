using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebApp.Protobufs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExampleWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly ILogger<ExampleController> _logger;

        public ExampleController(ILogger<ExampleController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]")]
        public IActionResult Empty() => Ok();

        [HttpPost("[action]")]
        public IActionResult Input([FromBody]ExampleProto proto)
        {
            return proto.Equals(ExampleProto.Input) ? Ok() : (IActionResult)BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult Output()
        {
            return Ok(ExampleProto.Output);
        }
    }
}
