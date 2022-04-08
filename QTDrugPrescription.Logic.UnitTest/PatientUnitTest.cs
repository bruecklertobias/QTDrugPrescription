using Microsoft.VisualStudio.TestTools.UnitTesting;
using QTDrugPrescription.Logic.Entities.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTDrugPrescription.Logic.UnitTest
{
    [TestClass]
    public class PatientUnitTest
    {
        [TestMethod]
        public void CheckSocialSecurityNumber_WithLetter_ExcpectedFalse()
        {
            var number = "123456a890";
            var actual = CheckSocialSecurityNumber.CheckNumber(number);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CheckSocialSecurityNumber_WithLength9_ExcpectedFalse()
        {
            var number = "123456890";
            var actual = CheckSocialSecurityNumber.CheckNumber(number);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CheckSocialSecurityNumber_WithLength11_ExcpectedFalse()
        {
            var number = "12345678901";
            var actual = CheckSocialSecurityNumber.CheckNumber(number);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CheckSocialSecurityNumber_WrongNumber_ExcpectedFalse()
        {
            var number = "3286171076";
            var actual = CheckSocialSecurityNumber.CheckNumber(number);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CheckSocialSecurityNumber_ExistingNumber_ExcpectedTrue()
        {
            var number = "3285171076";
            var actual = CheckSocialSecurityNumber.CheckNumber(number);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CheckSocialSecurityNumber_ExistingNumber1_ExcpectedTrue()
        {
            var number = "6074230703";
            var actual = CheckSocialSecurityNumber.CheckNumber(number);

            Assert.IsTrue(actual);
        }

        /*[TestMethod]
        public void CheckPatientFirstName_TooShortName_ExcpectedFalse()
        {
            Patient patient = new Patient();
            patient.FirstName = "To";
            patient.LastName = "Brückler";
            patient.SSN = "3285171076";
            patient.Birthday = DateTime.Now;

            Assert.IsTrue(actual);
        }*/

        /*[TestMethod]
        public void CheckPatientFirstName_ValidName_ExcpectedTrue()
        {
            var name = "Tobias";
            var actual = CheckSocialSecurityNumber.CheckNumber(number);

            Assert.IsTrue(actual);
        }*/
    }
}
