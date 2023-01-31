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
        [HttpGet("ByName")]
        public IEnumerable<Employees> Get(string Name)
        {

            var results = _employee.GetByName(Name);
            return results;
        }
        [HttpPost]
        public IActionResult Post(Employees employee)
        {

            try
            {
                var newEmployee = _employee.Insert(employee);
                return CreatedAtAction("Get", new { id = newEmployee.Id }, newEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
        [HttpPut]
        public IActionResult Put(Employees employee)
        {

            try
            {
                var editEmployee = _employee.Update(employee);
                return Ok(editEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(String Oid)
        {

            try
            {
                 _employee.Delete(Oid);
                return Ok($"Delete id {Oid} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
