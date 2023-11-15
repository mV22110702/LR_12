using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LR_12.Models
{
    public class EditCompanyViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Established date")]
        public DateTime EstablishedDate { get; set; }
    }
}
