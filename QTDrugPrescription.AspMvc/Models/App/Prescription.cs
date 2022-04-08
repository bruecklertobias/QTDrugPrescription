using System.ComponentModel.DataAnnotations;

namespace QTDrugPrescription.AspMvc.Models
{
    public class Prescription : VersionModel
    {
        public int PatientId { get; set; }
        public int DrugId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required, MaxLength(1024)]
        public string Dosing { get; set; } = string.Empty;

        public string DrugName { get; set; } = string.Empty;
        public Logic.Entities.App.Drug[] Drugs { get; set; } = Array.Empty<Logic.Entities.App.Drug>();

        public string PatientName { get; set; } = string.Empty;
        public Logic.Entities.App.Patient[] Patients { get; set; } = Array.Empty<Logic.Entities.App.Patient>();
    }
}
