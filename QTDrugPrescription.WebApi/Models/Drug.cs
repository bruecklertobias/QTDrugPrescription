namespace QTDrugPrescription.WebApi.Models
{
    public class Drug : VersionModel
    {
        public string Number { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }
}
