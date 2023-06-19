using MyPersonalApp.Models;

namespace MyPersonalApp.DTO
{
    public class EmployeeGetDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int PositionId { get; set; }
        public List<Position>? PositionName { get; set; }
    }
}
