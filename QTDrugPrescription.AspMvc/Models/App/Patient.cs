using System.ComponentModel.DataAnnotations;

namespace QTDrugPrescription.AspMvc.Models
{
    public class Patient : VersionModel
    {
        [Required]
        public DateTime Birthday { get; set; }
        [Required, MaxLength(10)]
        public string SSN { get; set; } = string.Empty;
        [Required, MaxLength(64)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(64)]
        public string LastName { get; set; } = string.Empty;
    }
}
