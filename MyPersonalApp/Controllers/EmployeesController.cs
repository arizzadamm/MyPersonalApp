using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPersonalApp.Models;

namespace MyPersonalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet]
        public Employees Get()
        {
            Employees _employee  = new()
            {
                Id = 1, Name = "Bondan Haryo"
            };
            return _employee;
        }
    }
}
