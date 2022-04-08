using QTDrugPrescription.Logic.Entities.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QTDrugPrescription.WpfApp.ViewModels
{
    public class PatientViewModel : BaseViewModel
    {
        private Logic.Controllers.PatientsController pCtrl = new Logic.Controllers.PatientsController();
        public DateTime BirthDay { get; set; }
        public string SSN { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;

        private ICommand? commandAdd;
        public ICommand CommandAdd
        {
            get
            {
                return RelayCommand.CreateCommand(ref commandAdd, p =>
                {
                    Add();
                },
                commandAdd => true);
            }
        }

        public void Add()
        {

            Patient patient = new Patient()
            {
                Birthday = BirthDay,
                SSN = SSN,
                FirstName = Firstname,
                LastName = Lastname
            };

            Task.Run(async () =>
            {
                try
                {
                    await pCtrl.InsertAsync(patient);
                    await pCtrl.SaveChangesAsync();
                    BirthDay = DateTime.Now;
                    SSN = string.Empty;
                    Firstname = string.Empty;
                    Lastname = string.Empty;
                    OnPropertyChanged(nameof(BirthDay));
                    OnPropertyChanged(nameof(SSN));
                    OnPropertyChanged(nameof(Firstname));
                    OnPropertyChanged(nameof(Lastname));
                }
                catch (Exception ex)
                {
                    string caption = "Patients";
                    string messageBoxText = ex.Message;

                }
            }).Wait();
        }
    }
}
