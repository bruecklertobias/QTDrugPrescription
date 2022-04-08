namespace QTDrugPrescription.WebApi.Models
{
    public class Patient : VersionModel
    {
        public DateTime Birthday { get; set; }
        public string SSN { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
