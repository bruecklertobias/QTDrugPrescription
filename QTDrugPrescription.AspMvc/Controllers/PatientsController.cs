using QTDrugPrescription.Logic.Controllers;
using QTDrugPrescription.Logic.Entities.App;

namespace QTDrugPrescription.AspMvc.Controllers
{
    public class PatientsController : GenericController<Logic.Entities.App.Patient, Models.Patient>
    {
        public PatientsController(Logic.Controllers.PatientsController controller) : base(controller)
        {
        }
    }
}
