using QTDrugPrescription.Logic.Entities;
using QTDrugPrescription.Logic.Entities.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTDrugPrescription.Logic.DataContext
{
    partial class ProjectDbContext
    {
        public DbSet<Drug> DrugSet { get; set; }
        public DbSet<Patient> PatientSet { get; set; }
        public DbSet<Prescription> PrescriptionSet { get; set; }

        partial void GetDbSet<E>(ref DbSet<E>? dbSet, ref bool handled) where E : IdentityEntity
        {
            if(typeof(E) == typeof(Drug))
            {
                handled = true;
                dbSet = DrugSet as DbSet<E>;
            }
            else if (typeof(E) == typeof(Patient))
            {
                handled = true;
                dbSet = PatientSet as DbSet<E>;
            }
            else if (typeof(E) == typeof(Prescription))
            {
                handled = true;
                dbSet = PrescriptionSet as DbSet<E>;
            }
        }
    }
}
