using System.ComponentModel.DataAnnotations;

namespace LogRegister.Models
{
    public class OtherDetails
    {
        [Key]
        public int EmpId { get; set; }
        public string Shift { get; set; }
        public string Location { get; set; }
        public string Visa { get; set; }
        public string Languages { get; set; }
    }
}
