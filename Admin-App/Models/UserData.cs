using System.ComponentModel.DataAnnotations;

namespace LogRegister.Models
{
    public class UserData
    {
        [Key]
        public int EmpId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
