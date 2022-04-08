using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTDrugPrescription.Logic.Entities.App
{
    [Table("Prescriptions", Schema = "App")]
    public class Prescription : VersionEntity
    {
        public int PatientId { get; set; }
        public int DrugId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required, MaxLength(1024)]
        public string Dosing { get; set; } = string.Empty;

        public Drug? Drug { get; set; }
        public Patient? Patient { get; set; }
    }
}
