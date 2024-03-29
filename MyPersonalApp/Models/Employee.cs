﻿using Microsoft.IdentityModel.Tokens;

namespace MyPersonalApp.Models
{
    public class Employees
    {
        public Guid Id { get; set; } 
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Phone { get; set; }
        public int PositionId { get; set; } 

        public string? Address { get; set; } 
        public string? City { get; set; }
        public string? Region { get; set; }
        public int PostalCode { get; set; }
        public string? Country { get; set; }
        public List<Position>? Positions { get; set; }   


    }
}
