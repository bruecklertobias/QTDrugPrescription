using QTDrugPrescription.Logic.Entities.App;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QTDrugPrescription.WpfApp.ViewModels
{
    public class PatientsViewModel : BaseViewModel
    {
        private Logic.Controllers.PatientsController pCtrl = new Logic.Controllers.PatientsController();
        public ObservableCollection<Patient> Patients
        {
            get
            {
                var models = Task.Run(async () => await pCtrl.GetAllAsync()).Result;

                models = models == null ? Array.Empty<Patient>() : models;

                return new ObservableCollection<Patient>(models);
            }
        }

        public int DataItemWidth { get; set; } = 200;

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
            var addWindow = new AddWindow();
            addWindow.ShowDialog();
            OnPropertyChanged(nameof(Patients));
        }
    }
}