using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication4.Models;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Annotations;


namespace WebApplication4.Controllers
{
    [Route("my/[action]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        private Model model;

        public MyController(Model model)
        {
            this.model = model;
        }

        [HttpPost]
        [SwaggerOperation("HandleInput", "Handles user input")]
        [SwaggerResponse(200, "OK", typeof(string))]
        public IActionResult HandleInput([FromBody] long number)
        {
            string result = model.SetNumber(number);
            return Ok(result);
        }
    }
}
