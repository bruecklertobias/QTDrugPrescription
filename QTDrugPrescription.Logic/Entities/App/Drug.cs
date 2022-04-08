using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTDrugPrescription.Logic.Entities.App
{
    [Table("Drugs", Schema = "App")]
    [Index(nameof(Number), IsUnique = true)]
    public class Drug : VersionEntity
    {
        [Required, MaxLength(10)]
        public string Number { get; set; } = string.Empty;

        [Required, MaxLength(128)]
        public string Designation { get; set; } = string.Empty;

        [Required, MaxLength(2048)]
        public string Note { get; set; } = string.Empty;
    }
}
