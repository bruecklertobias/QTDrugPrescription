using QTDrugPrescription.Logic.Controllers;
using QTDrugPrescription.Logic.Entities.App;

namespace QTDrugPrescription.WebApi.Controllers
{
    public class DrugsController : GenericController<Logic.Entities.App.Drug, Models.EditDrug, Models.Drug>
    {
        public DrugsController(Logic.Controllers.DrugsController controller) : base(controller)
        {
        }
    }
}
