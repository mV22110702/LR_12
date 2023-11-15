using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LR_12.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public int Age { get; set; }

        public int? CompanyID { get; set; }
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public Company? Company { get; set; }
    }
}
