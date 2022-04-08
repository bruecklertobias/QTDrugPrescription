using QTDrugPrescription.Logic.Entities.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTDrugPrescription.Logic.Controllers
{
    public class PrescriptionsController : GenericController<Prescription>
    {
        public PrescriptionsController()
        {
        }

        public PrescriptionsController(ControllerObject other) : base(other)
        {
        }

        public override Task<IEnumerable<Prescription>> InsertAsync(IEnumerable<Prescription> entities)
        {
            return base.InsertAsync(entities);
        }

        public override Task<Prescription> InsertAsync(Prescription entity)
        {
            return base.InsertAsync(entity);
        }

        public override Task<IEnumerable<Prescription>> UpdateAsync(IEnumerable<Prescription> entities)
        {
            return base.UpdateAsync(entities);
        }

        public override Task<Prescription> UpdateAsync(Prescription entity)
        {
            return base.UpdateAsync(entity);
        }

        private void ChangeDateFormat(Prescription entity)
        {
            string x = entity.Date.ToString("dd.MM.yyyy 00:00:00");
        }
    }
}
