using QTDrugPrescription.Logic.Entities.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTDrugPrescription.Logic.Controllers
{
    public class DrugsController : GenericController<Drug>
    {
        public DrugsController()
        {
        }

        public DrugsController(ControllerObject other) : base(other)
        {
        }

        public override Task<Drug> InsertAsync(Drug entity)
        {
            CheckEntity(entity);
            return base.InsertAsync(entity);
        }

        public override Task<IEnumerable<Drug>> InsertAsync(IEnumerable<Drug> entities)
        {
            entities.ToList().ForEach(entity => CheckEntity(entity));
            return base.InsertAsync(entities);
        }

        public override Task<Drug> UpdateAsync(Drug entity)
        {
            CheckEntity(entity);
            return base.UpdateAsync(entity);
        }

        public override Task<IEnumerable<Drug>> UpdateAsync(IEnumerable<Drug> entities)
        {
            entities.ToList().ForEach(entity => CheckEntity(entity));
            return base.UpdateAsync(entities);
        }

        private static void CheckEntity(Drug entity)
        {
            if (!CheckDrugNumber.CheckNumber(entity.Number))
            {
                throw new Exception("Invalid Drug Number");
            }

            if(entity.Designation.Length < 9)
            {
                throw new Exception("Too short Designation");
            }
        }
    }
}
