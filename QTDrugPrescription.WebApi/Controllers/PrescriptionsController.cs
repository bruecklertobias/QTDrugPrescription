using QTDrugPrescription.Logic.Controllers;
using QTDrugPrescription.Logic.Entities.App;

namespace QTDrugPrescription.WebApi.Controllers
{
    public class PrescriptionsController : GenericController<Logic.Entities.App.Prescription, Models.EditPrescription, Models.Prescription>
    {
        public PrescriptionsController(Logic.Controllers.PrescriptionsController controller) : base(controller)
        {
        }
    }
}
