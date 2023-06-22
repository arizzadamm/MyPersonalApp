using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyPersonalApp.DAL;
using MyPersonalApp.DTO;
using MyPersonalApp.Models;

namespace MyPersonalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPosition _position;
        private readonly IMapper _mapper;

        public PositionsController(IPosition positions,IMapper mapper)
        {
            _position = positions;
            _mapper = mapper;
            //_position = position;
        }
        [HttpGet]
        public IEnumerable<Position> Get()
        {
            //List<EmployeeGetDTO> lstemployeeGetDTO = new List<EmployeeGetDTO>();
            var results = _position.GetAll();
            return results;
            //foreach (var s in results)
            //    //{
            //    //    lstemployeeGetDTO.Add(new EmployeeGetDTO
            //    //    {
            //    //        Name = s.Name,
            //    //        Email = s.Email,
            //    //        PositionId = s.PositionId
            //    //    });
            //    //}
        }
        [HttpGet("ByPositionId")]
        public Position Get(int positionId)
        {
            var results = _position.GetByPositionId(positionId);
            return results;
        }
        [HttpPost]
        public IActionResult Post(PositionAddDTO positionAddDto)
        {

            try
            {
                var newPosition = _mapper.Map<Position>(positionAddDto);
                _position.Insert(newPosition);

                var positionGetDto = _mapper.Map<PositionGetDTO>(newPosition);

                return CreatedAtAction("Get", new { id = newPosition.Id }, newPosition);
                //var position = new Position
                //{
                //    PositionId = positionDTO.PositionId,
                //    PositionName = positionDTO.PositionName,
                //    Description = positionDTO.Description,
                //};
                //var newPosition = _position.Insert(position);
                //return CreatedAtAction("Get", new { id = newPosition.Id }, newPosition);
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
        public IActionResult Put(int positionID, PositionAddDTO positionAddDto)
        {

            try
            {

                var newPosition = _mapper.Map<Position>(positionAddDto);
                _position.Update(newPosition);

                var positionGetDto = _mapper.Map<PositionGetDTO>(newPosition);

                return CreatedAtAction("GetById", new { id = positionGetDto.PositionId }, positionGetDto);
                //    var position = new Position
                //    {
                //        PositionName = positionDTO.PositionName,
                //        PositionId = positionDTO.PositionId,
                //        Description = positionDTO.Description,
                //    };
                //    var editPosition = _position.Update(position);
                //    PositionAddDTO positiongetDTO = new()
                //    {
                //        PositionName = positionDTO.PositionName,
                //        PositionId = positionDTO.PositionId
                //    };
                //    return Ok(positiongetDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int PositionId)
        {

            try
            {
                _position.Delete(PositionId);
                return Ok($"Delete id {PositionId} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
