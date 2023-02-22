using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPersonalApp.DAL;
using MyPersonalApp.DTO;
using MyPersonalApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _employee;
        //private readonly IEmployee _position;

        public EmployeesController(IEmployee employee)
        {
            _employee = employee;
            //_position = position;
        }    
        [HttpGet]
        public IEnumerable<EmployeeGetDTO> Get()
        {
            List<EmployeeGetDTO> lstemployeeGetDTO = new List<EmployeeGetDTO>();
            var results = _employee.GetAll();   
            foreach (var s in results)
            {
                lstemployeeGetDTO.Add(new EmployeeGetDTO
                {
                    Name= s.Name,
                    Email= s.Email,
                    PositionId= s.PositionId
                });
            }
            return lstemployeeGetDTO;
        }
        [HttpGet("ByPositionId")]
        public Employees Get(int id) 
        {
            var results = _employee.GetByPositionId(id);
            return results;
        }
        [HttpGet("ByName")]
        public IEnumerable<EmployeeGetDTO> Get(string Name)
        {
            List<EmployeeGetDTO> lstemployeeGetDTO = new List<EmployeeGetDTO>();
            var results = _employee.GetByName(Name);
            foreach (var s in results)
            {
                lstemployeeGetDTO.Add(new EmployeeGetDTO
                {
                    Name = s.Name,
                    PositionId = s.PositionId,
                    Email = s.Email,
                });
            }
            //return results.Select(r => new Employees
            //{
            //    Name = r.Name,
            //    PositionId= r.PositionId,
            //    Positions = r.Positions,
            //    Email = r.Email,
            //    Phone= r.Phone,
            //    Address= r.Address,
            //    City= r.City,
            //    Country= r.Country


            //});
            //List<Employees> employees = new();
            //var results = _employee.GetByName(Name);
            //foreach (var r in results)
            //{
            //    employees.Add(new Employees
            //    {
            //        Name = r.Name,
            //    });
            //}
            //return employees;
            return lstemployeeGetDTO;
        }
        [HttpPost]
        public IActionResult Post(EmployeeAddDTO employeeDTO)
        {

            try
            {
                var employee = new Employees
                {
                    Name = employeeDTO.Name,
                    Email = employeeDTO.Email,
                    Phone = employeeDTO.Phone,
                    PositionId= employeeDTO.PositionId

                };
                var newEmployee = _employee.Insert(employee);
                return CreatedAtAction("Get", new { id = newEmployee.Id }, newEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
        //public IActionResult Post(PositionAddDTO positionDTO)
        //{

        //    try
        //    {
        //        var position = new Position
        //        {
        //                PositionId = positionDTO.PositionId,
        //                Description= positionDTO.Description,
        //                PositionName= positionDTO.PositionName

        //        };
        //        var newPosition = _position.Insert(position);
        //        return CreatedAtAction("Get", new { id = newPosition.Id }, newPosition);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [HttpPut]
        public IActionResult Put(EmployeeAddDTO employeeDTO)
        {

            try
            {
                var employee = new Employees
                {
                    Name = employeeDTO.Name,
                    PositionId = employeeDTO.PositionId
                };
                var editEmployee = _employee.Update(employee);
                EmployeeGetDTO employeeGetDTO = new ()
                {
                    Name = employeeDTO.Name,
                    PositionId = employeeDTO.PositionId
                };
                return Ok(employeeGetDTO);
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
