using System.ComponentModel.DataAnnotations;

namespace LR_12.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
