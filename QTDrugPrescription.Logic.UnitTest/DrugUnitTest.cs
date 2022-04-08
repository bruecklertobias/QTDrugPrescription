using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTDrugPrescription.Logic.UnitTest
{
    [TestClass]
    public class DrugUnitTest
    {
        [TestMethod]
        public void CheckDrugNumber_WithLetterNotCheckDigitX_ExcpectedFalse()
        {
            var number = "123456a890";
            var actual = CheckDrugNumber.CheckNumber(number);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CheckDrugNumber_WithLength9_ExcpectedFalse()
        {
            var number = "123456890";
            var actual = CheckDrugNumber.CheckNumber(number);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CheckDrugNumber_WithLength11_ExcpectedFalse()
        {
            var number = "12345678901";
            var actual = CheckDrugNumber.CheckNumber(number);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CheckDrugNumber_WrongNumber_ExcpectedFalse()
        {
            var number = "3286171076";
            var actual = CheckDrugNumber.CheckNumber(number);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CheckDrugNumber_ExistingNumberWithCheckDigitX_ExcpectedTrue()
        {
            var number = "349913599X";
            var actual = CheckDrugNumber.CheckNumber(number);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CheckDrugNumber_ExistingNumber1_ExcpectedTrue()
        {
            var number = "3446193138";
            var actual = CheckDrugNumber.CheckNumber(number);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CheckDrugNumber_ExistingNumber2_ExcpectedTrue()
        {
            var number = "0747551006";
            var actual = CheckDrugNumber.CheckNumber(number);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CheckDrugNumber_ExistingNumber3_ExcpectedTrue()
        {
            var number = "1572314222";
            var actual = CheckDrugNumber.CheckNumber(number);

            Assert.IsTrue(actual);
        }
    }
}
