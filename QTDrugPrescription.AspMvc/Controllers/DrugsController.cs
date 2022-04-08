using QTDrugPrescription.Logic.Controllers;
using QTDrugPrescription.Logic.Entities.App;

namespace QTDrugPrescription.AspMvc.Controllers
{
    public class DrugsController : GenericController<Logic.Entities.App.Drug, Models.Drug>
    {
        public DrugsController(Logic.Controllers.DrugsController controller) : base(controller)
        {
        }
    }
}
