using QTDrugPrescription.Logic.Entities.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTDrugPrescription.Logic.Controllers
{
    public class PatientsController : GenericController<Patient>
    {
        public PatientsController()
        {
        }

        public PatientsController(ControllerObject other) : base(other)
        {
        }

        public override Task<Patient> InsertAsync(Patient entity)
        {
            CheckEntity(entity);
            return base.InsertAsync(entity);
        }

        public override Task<IEnumerable<Patient>> InsertAsync(IEnumerable<Patient> entities)
        {
            entities.ToList().ForEach(entity => CheckEntity(entity));
            return base.InsertAsync(entities);
        }

        public override Task<Patient> UpdateAsync(Patient entity)
        {
            CheckEntity(entity);
            return base.UpdateAsync(entity);
        }

        public override Task<IEnumerable<Patient>> UpdateAsync(IEnumerable<Patient> entities)
        {
            entities.ToList().ForEach(entity => CheckEntity(entity));
            return base.UpdateAsync(entities);
        }

        private static void CheckEntity(Patient entity)
        {
            if(!CheckSocialSecurityNumber.CheckNumber(entity.SSN))
            {
                throw new Exception("Invalid SSN number");
            }
            if(entity.FirstName.Length < 3)
            {
                throw new Exception("Too short FirstName");
            }
            if (entity.LastName.Length < 3)
            {
                throw new Exception("Too short LastName");
            }
        }
    }
}
