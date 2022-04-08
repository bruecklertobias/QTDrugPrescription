using QTDrugPrescription.Logic.Controllers;
using QTDrugPrescription.Logic.Entities.App;

namespace QTDrugPrescription.AspMvc.Controllers
{
    public class PrescriptionsController : GenericController<Logic.Entities.App.Prescription, Models.Prescription>
    {
        public PrescriptionsController(Logic.Controllers.PrescriptionsController controller) : base(controller)
        {
        }

        private Logic.Entities.App.Patient[]? patients = null;
        private Logic.Controllers.PatientsController? patientsController = null;

        private Logic.Entities.App.Drug[]? drugs = null;
        private Logic.Controllers.DrugsController? drugsController = null;

        protected Logic.Entities.App.Patient[] Patients
        {
            get
            {
                if (patients == null)
                {
                    Task.Run(async () => patients = await PatientsController.GetAllAsync()).Wait();
                }
                return patients ??= Array.Empty<Logic.Entities.App.Patient>();
            }
        }

        private Logic.Controllers.PatientsController PatientsController
        {
            get => patientsController ??= new Logic.Controllers.PatientsController(Controller);
        }

        protected Logic.Entities.App.Drug[] Drugs
        {
            get
            {
                if (drugs == null)
                {
                    Task.Run(async () => drugs = await DrugsController.GetAllAsync()).Wait();
                }
                return drugs ??= Array.Empty<Logic.Entities.App.Drug>();
            }
        }

        private Logic.Controllers.DrugsController DrugsController
        {
            get => drugsController ??= new Logic.Controllers.DrugsController(Controller);
        }

        protected override Models.Prescription ToModel(Logic.Entities.App.Prescription entity)
        {
            var result = base.ToModel(entity);
            var patient = Patients.FirstOrDefault(p => p.Id == result.PatientId);
            var drug = Drugs.FirstOrDefault(p => p.Id == result.DrugId);

            result.Patients = Patients;
            result.Drugs = Drugs;

            if (patient != null)
                result.PatientName = patient.LastName;

            if (drug != null)
                result.DrugName = drug.Designation;

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            PatientsController?.Dispose();
            DrugsController?.Dispose();
            base.Dispose(disposing);
        }
    }
}
