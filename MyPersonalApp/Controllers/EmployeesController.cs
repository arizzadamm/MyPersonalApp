using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPersonalApp.DAL;
using MyPersonalApp.Models;

namespace MyPersonalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeesController(IEmployee employee)
        {
            _employee = employee;   
        }    
        [HttpGet]
        public IEnumerable<Employees> Get()
        {

            var results = _employee.GetAll();   
            return results;
        }
        [HttpGet("GetByName/{Name}")]
        public IEnumerable<Employees> Get(string Name)
        {

            var results = _employee.GetByName(Name);
            return results;
        }
    }
}
