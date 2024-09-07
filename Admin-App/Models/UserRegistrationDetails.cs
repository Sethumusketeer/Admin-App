using System.ComponentModel.DataAnnotations;

namespace LogRegister.Models
{
    public class UserRegistrationDetails
    {
        [Key]
        public string Name { get; set; }
        public string PersonalEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
    }
}
