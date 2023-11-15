using System.ComponentModel.DataAnnotations;

namespace LR_12.Models
{
    public class Company
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string EstablishedDate { get; set; }
        public List<User> Workers { get; set; }
    }
}
