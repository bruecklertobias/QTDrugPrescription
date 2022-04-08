using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Extensions
{
    public static class CheckDrugNumber
    {
        public static bool CheckNumber(string number)
        {
            int checksum = 0;

            if(number.Length != 10) return false;

            for (int i = 0; i < number.Length-1; i++)
            {
                checksum += (number[i] - '0') * (i+1);
            }

            if(checksum % 11 == 10 && char.ToLower(number[9]) == 'x') return true;
            if (checksum % 11 == (number[9] - '0')) return true;

            return false;
        }
    }
}
