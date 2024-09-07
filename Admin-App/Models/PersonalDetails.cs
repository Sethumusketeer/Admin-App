using System.ComponentModel.DataAnnotations;

namespace LogRegister.Models
{
    public class PersonalDetails
    {
        [Key]
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string PersonalEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
