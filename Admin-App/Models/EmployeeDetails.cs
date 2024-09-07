using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LogRegister.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string PersonalEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string? Email { get; set; }
        public string? Designation { get; set; }
        public DateTime? DateJoined { get; set; }
        public string? JobTitle { get; set; }
        public string? Department { get; set; }
        public string? Manager { get; set; }
        public string? Shift { get; set; }
        public string? Location { get; set; }
        public string? Visa { get; set; }
        public string? Languages { get; set; }
        public FileContentResult? ImageData { get; set; }
    }
}
