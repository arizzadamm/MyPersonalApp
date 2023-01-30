using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "This is list of employee";
        }
    }
}
