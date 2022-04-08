namespace QTDrugPrescription.WebApi.Models
{
    public class EditPrescription
    {
        public int PatientId { get; set; }
        public int DrugId { get; set; }
        public DateTime Date { get; set; }
        public string Dosing { get; set; } = string.Empty;
    }
}
