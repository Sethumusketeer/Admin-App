using System.ComponentModel.DataAnnotations;

namespace LogRegister.Models
{
    public class ProfilePicture
    {
        [Key]
        public int EmpId { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageData { get; set; }
    }
}
