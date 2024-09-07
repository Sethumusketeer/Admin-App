using System.ComponentModel.DataAnnotations;

namespace LogRegister.Models
{
    public class ProfessionalDetails
    {
        [Key]
        public int EmpId { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public DateTime DateJoined { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Manager { get; set; }

    }
}
