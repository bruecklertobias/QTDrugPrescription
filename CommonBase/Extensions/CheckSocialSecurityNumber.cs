using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Extensions
{
    public static class CheckSocialSecurityNumber
    {
        public static bool CheckNumber(string ssn)
        {
            int checksum = 0;
            int[] multipliers = new int[] { 3, 7, 9, 5, 8, 4, 2, 1, 6 };

            if(ssn.Length != 10)
            {
                return false;
            }

            for (int i = 0; i < ssn.Length - 1; i++)
            {
                if (i < 3) checksum += (ssn[i] - '0') * multipliers[i];
                else checksum += (ssn[i+1] - '0') * multipliers[i];
            }

            if (checksum % 11 == (ssn[3] - '0')) return true;

            return false;
        }
    }
}
