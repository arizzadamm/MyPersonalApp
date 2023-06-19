namespace MyPersonalApp.Models
{
    public class Position
    {
        public Guid Id { get; set; }
        public int PositionId { get; set; } 
        public string? PositionName { get; set; }
        public string? Description { get; set; }  
        public Employees? Employees { get; set; }
     
    }
}
