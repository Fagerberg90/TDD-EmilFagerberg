using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var numberArray = numbers.Replace('\n', ',').Split(',');

            GetNumberArrayDefaultDelimeter(ref numberArray);

            return numberArray.Sum(x => int.Parse(x));


        }


        private static void GetNumberArrayDefaultDelimeter(ref string[] numberArray)
        {

            if (!numberArray[0].StartsWith("//"))

                return;

            var delimeter = Convert.ToChar(numberArray[0].Remove(0, 2));

            numberArray = numberArray[1].Split(delimeter);
        }
    }
}

