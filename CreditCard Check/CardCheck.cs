//       Luhn checking algorithm class
//
// CheckNumber requires a string of numbers, including check digit, 
// and returns True if that number passes.
// No type checking is performed.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard_Check
{
    public static class CardCheck
    {
        public static bool CheckNumber(string numberToCheck)
        {
            int result = 0;
            int position = 0;
            int sum = 0;

            for (int i = 1; i < numberToCheck.Length; i++)                                          // Start at penulimate right most digit IE Not checksum 
            {
                result = Convert.ToInt32(numberToCheck.Substring(numberToCheck.Length - 1 - i, 1)); // Digit at position i from right
                if (position % 2 == 0)                                                              
                    result = result * 2;                                                                     
                if (result > 9)
                    result -= 9;
                sum += result;
                position++;
            }
            if ((10 - (sum % 10) == Convert.ToInt32(numberToCheck.Substring(numberToCheck.Length - 1)))) // Check sum with check digit
            {
                return true;
            }
            return false;
        }
    }
}
